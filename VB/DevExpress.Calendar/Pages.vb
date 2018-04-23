Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars
Imports System.Diagnostics

Namespace DevExpress.Calendar
	Public NotInheritable Class Pages
		Private Shared s_ContentPresenter As Control
		Private Sub New()
		End Sub
		Public Shared Property ContentPresenter() As Control
			Get
				Return s_ContentPresenter
			End Get
			Set(ByVal value As Control)
				s_ContentPresenter = value
			End Set
		End Property
		Public Shared Sub RegisterContentPresenter(ByVal contentPresenter As Control)
			Pages.ContentPresenter = contentPresenter
		End Sub

		Private Shared s_WaitPresenter As Control
		Private Shared s_WaitControlsList() As Control

		Public Shared Sub RegisterWaitPresenter(ByVal waitPresenter As Control, ParamArray ByVal waitControlsList() As Control)
			s_WaitPresenter = waitPresenter
			s_WaitControlsList = waitControlsList

			If s_WaitPresenter IsNot Nothing Then
				s_WaitPresenter.Hide()
			End If
		End Sub

		Private Shared s_IsWaiting As Integer = 0

		Public Shared Sub ShowWaitPanel()
			Dim isWaiting As Integer = System.Threading.Interlocked.Increment(s_IsWaiting)
			Debug.Assert(isWaiting > 0)

			If isWaiting > 0 Then

				If s_WaitPresenter IsNot Nothing Then
					s_WaitPresenter.Show()
					s_WaitPresenter.BringToFront()
					Application.DoEvents()
				End If

				If isWaiting = 0 Then
					If s_WaitControlsList IsNot Nothing Then
						For Each c As Control In s_WaitControlsList
							If c IsNot Nothing Then
								c.Enabled = False
							End If
						Next c
					End If
				End If
			End If
		End Sub

		Public Shared Sub HideWaitPanel()
			Dim isWaiting As Integer = System.Threading.Interlocked.Decrement(s_IsWaiting)
			Debug.Assert(isWaiting >= 0)

			If isWaiting = 0 Then
				If s_WaitPresenter IsNot Nothing Then
					s_WaitPresenter.Hide()
				End If
				If s_WaitControlsList IsNot Nothing Then
					For Each c As Control In s_WaitControlsList
						If c IsNot Nothing Then
							c.Enabled = True
						End If
					Next c
				End If
			End If
		End Sub

		Private Shared s_ActivePage As Control
		Public Shared Property ActivePage() As Control
			Get
				Return s_ActivePage
			End Get
			Set(ByVal value As Control)
				s_ActivePage = value
			End Set
		End Property

		Private Shared s_Pages As New Dictionary(Of Type, UserControl)()

		Public Shared Sub [GoTo](Of T As {UserControl, New})(ByVal e As PageLoadEventArgs)

			If s_ContentPresenter Is Nothing Then
				Return
			End If

			Using TempWaitCursor As WaitCursor = New WaitCursor()

				ShowWaitPanel()
				s_ContentPresenter.SuspendLayout()

				Try
					Dim c As UserControl = Nothing

					If (Not s_Pages.TryGetValue(GetType(T), c)) Then
						c = Nothing
					End If

					If c Is Nothing Then
						c = New T()
						c.Parent = s_ContentPresenter
						c.Dock = DockStyle.Fill
						s_Pages.Add(GetType(T), c)
					End If

					s_ActivePage = c

					c.Show()
					c.BringToFront()

					If s_WaitPresenter IsNot Nothing Then
						s_WaitPresenter.Show()
						s_WaitPresenter.BringToFront()
					End If



					Dim page As IPage = TryCast(c, IPage)

					If page IsNot Nothing Then
						page.Page_Load(e)
					End If

					If c.Handle <> IntPtr.Zero Then
						c.Invoke(New Action(Function() AnonymousMethod1(c)))
					End If

				Finally

					s_ContentPresenter.ResumeLayout()
					HideWaitPanel()

				End Try

			End Using
		End Sub
		
		Private Shared Function AnonymousMethod1(ByVal c As UserControl) As Boolean
			c.Focus()
			Return True
		End Function
	End Class
End Namespace

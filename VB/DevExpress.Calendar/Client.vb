Imports Microsoft.VisualBasic
	Imports System
	Imports System.Collections.Generic
	Imports System.ComponentModel
	Imports System.Data
	Imports System.Drawing
	Imports System.Text
	Imports System.Windows.Forms
	Imports DevExpress.XtraBars
	Imports DevExpress.Calendar.Parts
	Imports DevExpress.Xpo
	Imports System.Configuration
	Imports DevExpress.Calendar.Model
	Imports System.Linq
	Imports System.Security.Principal
	Imports System.Diagnostics
Namespace DevExpress.Calendar

	Partial Public Class Client
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm

		Public Sub New()
			InitializeComponent()
			defaultLookAndFeel.LookAndFeel.SkinName = "Office 2010 Blue"

			Pages.RegisterContentPresenter(clientPanel)
			Pages.RegisterWaitPresenter(pictureBox1, Me)

			PopulateUserFilter()

			If Security.Current.User IsNot Nothing Then

				barStaticCurrentUser.Caption = Security.Current.User.DisplayText
			Else

				barStaticCurrentUser.Caption = WindowsIdentity.GetCurrent().Name
			End If

			Pages.GoTo(Of Home)(Nothing)
		End Sub

		Private Sub PopulateUserFilter()

			Dim currentUserName As String = WindowsIdentity.GetCurrent().Name.ToLower()

			AddHandler userFilterBarButton.ItemClick, Function(sender, e) AnonymousMethod1(sender, e)

			userFilterPopupMenu.BeginUpdate()
			Try

				AddHandler userFilterPopupMenu.Popup, Function(sender, e) AnonymousMethod2(sender, e)

				Dim itemsToDispose As New List(Of IDisposable)()

				For Each itemLink As BarItemLink In userFilterPopupMenu.ItemLinks
					Dim disp As IDisposable = TryCast(itemLink.Item, IDisposable)
					If disp IsNot Nothing Then
						itemsToDispose.Add(disp)
					End If
				Next itemLink

				For Each disp As IDisposable In itemsToDispose
					disp.Dispose()
				Next disp

				userFilterPopupMenu.ItemLinks.Clear()

				Dim users = _
					From p In New Model.Service(Program.Service).Resources _
					Order By p.Name _
					Select p

				Dim currentUserBarItem As BarCheckItem = Nothing

				For Each u As Resource In users

					Dim bIsCurrentUser As Boolean = (u.UserName.ToLower().Contains(currentUserName))

					Dim barCheckItem As New BarCheckItem()
					barCheckItem.Caption = u.ToString()
					barCheckItem.AllowAllUp = True
					barCheckItem.GroupIndex = &HFF
					barCheckItem.Checked = bIsCurrentUser
					barCheckItem.Tag = u

					AddHandler barCheckItem.CheckedChanged, Function(sender, e) AnonymousMethod3(sender, e)

					If (Not bIsCurrentUser) Then
						userFilterPopupMenu.ItemLinks.Add(barCheckItem)
					Else
						currentUserBarItem = barCheckItem
					End If
				Next u

				If currentUserBarItem IsNot Nothing Then
						userFilterBarButton.Tag = currentUserBarItem.Tag

					If userFilterPopupMenu.ItemLinks.Count > 0 Then
						userFilterPopupMenu.ItemLinks(0).BeginGroup = True
					End If

					userFilterPopupMenu.ItemLinks.Insert(0, currentUserBarItem)
				End If

				Filter.Current.User = If(currentUserBarItem IsNot Nothing, TryCast(currentUserBarItem.Tag, Resource), Nothing)

				Security.Current.User = Filter.Current.User

			Finally
				userFilterPopupMenu.EndUpdate()
			End Try
		End Sub
		
		Private Function AnonymousMethod1(ByVal sender As Object, ByVal e As ItemClickEventArgs) As Boolean
			Dim user As Resource = TryCast(e.Item.Tag, Resource)
			Debug.Assert(user IsNot Nothing)
			Filter.Current.User = user
			Return True
		End Function
		
		Private Function AnonymousMethod2(ByVal sender As Object, ByVal e As EventArgs) As Boolean
			For Each itemLink As BarItemLink In userFilterPopupMenu.ItemLinks
				If TypeOf itemLink.Item.Tag Is Resource AndAlso Filter.Current.User IsNot Nothing AndAlso (CType(itemLink.Item.Tag, Resource)).ID = Filter.Current.User.ID Then
					CType(itemLink.Item, BarCheckItem).Checked = True
				Else
					CType(itemLink.Item, BarCheckItem).Checked = False
				End If
			Next itemLink
			Return True
		End Function
		
		Private Function AnonymousMethod3(ByVal sender As Object, ByVal e As ItemClickEventArgs) As Boolean
			Dim user As Resource = TryCast(e.Item.Tag, Resource)
			Debug.Assert(user IsNot Nothing)
			If Not(CType(e.Item, BarCheckItem)).Checked Then
				user = Nothing
			End If
			Filter.Current.User = user
			Return True
		End Function

		Private Sub newItemBarButton_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles newItemBarButton.ItemClick
			Dim Calendar As ICalendar = TryCast(Pages.ActivePage, ICalendar)
			If Calendar IsNot Nothing Then
				Calendar.Create(Appointment.ItemCode.Task)
			End If
		End Sub

		Private Sub newTaskBarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles newTaskBarButtonItem.ItemClick
			Dim Calendar As ICalendar = TryCast(Pages.ActivePage, ICalendar)
			If Calendar IsNot Nothing Then
				Calendar.Create(Appointment.ItemCode.Task)
			End If
		End Sub

		Private Sub newAppointmentBarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles newAppointmentBarButtonItem.ItemClick
			Dim Calendar As ICalendar = TryCast(Pages.ActivePage, ICalendar)
			If Calendar IsNot Nothing Then
				Calendar.Create(Appointment.ItemCode.Appointment)
			End If
		End Sub

		Private Sub newEventBarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles newEventBarButtonItem.ItemClick
			Dim Calendar As ICalendar = TryCast(Pages.ActivePage, ICalendar)
			If Calendar IsNot Nothing Then
				Calendar.Create(Appointment.ItemCode.Event)
			End If
		End Sub

		Private Sub newMeetingBarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles newMeetingBarButtonItem.ItemClick
			Dim Calendar As ICalendar = TryCast(Pages.ActivePage, ICalendar)
			If Calendar IsNot Nothing Then
				Calendar.Create(Appointment.ItemCode.Meeting)
			End If
		End Sub

		Private Sub newProjectBarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles newProjectBarButtonItem.ItemClick
			Dim Calendar As ICalendar = TryCast(Pages.ActivePage, ICalendar)
			If Calendar IsNot Nothing Then
				Calendar.Create(Appointment.ItemCode.Project)
			End If
		End Sub
	End Class
End Namespace
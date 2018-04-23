Imports Microsoft.VisualBasic
Imports System
	Imports DevExpress.Xpo
Namespace DevExpress.Calendar.Model
#If (Not WIN) Then
#End If
	Partial Public Class Resource
#If (Not WIN) Then
		<NonPersistent> _
		Public ReadOnly Property DisplayText() As String
#Else
		Public ReadOnly Property DisplayText() As String
#End If
			Get
				Return ToString()
			End Get
		End Property

		''' <summary>Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</summary>
		''' <returns>A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</returns>
		''' <filterpriority>2</filterpriority>
		Public Overrides Function ToString() As String
			Dim name As String = Me.Name

			If (Not String.IsNullOrEmpty(name)) Then
				Return name
			End If

			Dim email As String = Me.Email

			If (Not String.IsNullOrEmpty(email)) Then
				Return email
			End If

			Dim userName As String = Me.UserName

			If (Not String.IsNullOrEmpty(userName)) Then
				Return userName
			End If

			Return MyBase.ToString()
		End Function
	End Class
End Namespace
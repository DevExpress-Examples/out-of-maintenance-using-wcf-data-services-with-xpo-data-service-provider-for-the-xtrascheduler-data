Imports Microsoft.VisualBasic
	Imports System
	Imports DevExpress.Calendar.Model
Namespace DevExpress.Calendar
	Public Class Security
		Public Shared ReadOnly Current As New Security()

		Public Sub New()
		End Sub

		Public Event UserChanged As EventHandler
		Private Sub RaiseUserChanged()
			RaiseEvent UserChanged(User, New EventArgs())
		End Sub

		Private _user As Resource
		Public Sub SetCurrentUser(ByVal value As Resource)
			_user = value
		End Sub
		Public Property User() As Resource
			Get
				Return _user
			End Get
			Set(ByVal value As Resource)
				If _user IsNot value Then
					_user = value
					RaiseUserChanged()
				End If
			End Set
		End Property
	End Class
End Namespace

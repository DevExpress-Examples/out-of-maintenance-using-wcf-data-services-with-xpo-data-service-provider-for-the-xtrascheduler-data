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

	Public Class Filter
		Public Shared ReadOnly Current As New Filter()

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
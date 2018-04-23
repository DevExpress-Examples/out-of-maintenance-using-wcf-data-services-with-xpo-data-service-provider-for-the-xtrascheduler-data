Imports Microsoft.VisualBasic
#If DEBUG Then
	Imports System
	Imports System.Data.Services
	Imports System.Data.Services.Client
	Imports System.Linq
	Imports Microsoft.VisualStudio.TestTools.UnitTesting
	Imports DevExpress.Calendar
	Imports DevExpress.Calendar.Model
	Imports DevExpress.Data.Filtering
	Imports System.Security.Principal
Namespace DevExpress.Xpo.Services

	<TestClass> _
	Public Class TestService

		Private _session As UnitOfWork
		Private ReadOnly Property Session() As UnitOfWork
			Get
				If _session Is Nothing Then
					_session = New UnitOfWork()
					Using service As New Service()
						_session.ConnectionString = service.ConnectionString
					End Using
				End If
				Return _session
			End Get
		End Property

		<TestMethod> _
		Public Sub CreateUsers()
			Dim bHasChanges As Boolean = False

			Dim user As Resource = Session.FindObject(Of Resource)(New BinaryOperator("Email", "bill.gates@devexpress.com"))
			If user Is Nothing Then
				user = New Resource(Session)
				user.UserName = WindowsIdentity.GetCurrent().Name
				user.Name = "Bill Gates"
				user.Email = "bill.gates@devexpress.com"
				user.Save()
				bHasChanges = True
			End If

			user = Session.FindObject(Of Resource)(New BinaryOperator("Email", "bill.clinton@devexpress.com"))
			If user Is Nothing Then
				user = New Resource(Session)
				user.UserName = "DEVEXPRESS\BillC"
				user.Name = "Bill Clinton"
				user.Email = "bill.clinton@devexpress.com"
				user.Save()
				bHasChanges = True
			End If

			If bHasChanges Then
				Session.CommitChanges()
			End If
		End Sub

	End Class
End Namespace
#End If
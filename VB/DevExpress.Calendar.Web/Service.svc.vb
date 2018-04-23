Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports DevExpress.Xpo.Services
Imports DevExpress.Calendar.Model
Imports DevExpress.Xpo

Namespace DevExpress.Calendar
	Public Class Service
		Inherits XpoDataService
		Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
			config.SetEntitySetAccessRule("*", EntitySetRights.All)
			config.SetServiceOperationAccessRule("*", ServiceOperationRights.All)
			config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2
			config.UseVerboseErrors = True
		End Sub

		Protected Overrides Sub OnStartProcessingRequest(ByVal args As ProcessRequestArgs)
			MyBase.OnStartProcessingRequest(args)
		End Sub

		Public Overrides ReadOnly Property AutoCreateOption() As Xpo.DB.AutoCreateOption
			Get
				Return Xpo.DB.AutoCreateOption.DatabaseAndSchema
			End Get
		End Property

		Public Overrides ReadOnly Property ConnectionString() As String
			Get
				Return "Data Source=.\SQLExpress;Initial Catalog=Calendar;Integrated Security=True"
			End Get
		End Property

		Protected Overrides Sub RegisterEntities()
			Me.RegisterEntity(GetType(Appointment))
			Me.RegisterEntity(GetType(Resource))
			MyBase.RegisterEntities()
		End Sub

	End Class
End Namespace

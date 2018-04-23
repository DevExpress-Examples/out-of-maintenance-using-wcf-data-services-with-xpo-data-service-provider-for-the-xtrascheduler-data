Imports Microsoft.VisualBasic
	Imports System
	Imports System.Collections.Generic
	Imports System.Text
	Imports DevExpress.Xpo
	Imports DevExpress.Xpo.Metadata
	Imports DevExpress.Xpo.Services
	Imports DevExpress.Data.Services
Namespace DevExpress.Calendar.Model
#If (Not WIN) Then
#End If

#If (Not WIN) Then
    <ResourceSetName("Resources")> _
Partial Public Class Resource
        Inherits XPCustomObject
#Else
<Persistent("Resources")> _
	Partial Public Class Resource
		Inherits XPCustomObject
#End If

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New()
        End Sub

        Public Sub New(ByVal session As Session, ByVal classInfo As XPClassInfo)
            MyBase.New(session, classInfo)
        End Sub

        Private _id As Guid
        <Key(AutoGenerate:=True)> _
        Public Property ID() As Guid
            Get
                Return _id
            End Get
            Set(ByVal value As Guid)
                SetPropertyValue("ID", _id, value)
            End Set
        End Property

        Private _email As String
        <Size(256)> _
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Email", _email, value)
            End Set
        End Property

        Private _userName As String
        <Size(256)> _
        Public Property UserName() As String
            Get
                Return _userName
            End Get
            Set(ByVal value As String)
                SetPropertyValue("UserName", _userName, value)
            End Set
        End Property

        Private _name As String
        <Size(256)> _
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Name", _name, value)
            End Set
        End Property

        <Association("Appointments-Resources", UseAssociationNameAsIntermediateTableName:=True)> _
        Public ReadOnly Property Appointments() As XPCollection(Of Appointment)
            Get
                Return GetCollection(Of Appointment)("Appointments")
            End Get
        End Property
    End Class
End Namespace
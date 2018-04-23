Imports Microsoft.VisualBasic
	Imports System
	Imports DevExpress.Xpo
	Imports DevExpress.XtraScheduler
	Imports DevExpress.XtraScheduler.Xml
	Imports DevExpress.Xpo.Services
	Imports DevExpress.Data.Services
Namespace DevExpress.Calendar.Model

#If (Not WIN) Then
    <ResourceSetName("Appointments")> _
Partial Public Class Appointment
        Inherits XPCustomObject
#Else
<Persistent("Appointments")> _
Partial Public Class Appointment
        Inherits XPCustomObject
#End If

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Sub New()
        End Sub

        Public Sub New(ByVal session As Session, ByVal classInfo As DevExpress.Xpo.Metadata.XPClassInfo)
            MyBase.New(session, classInfo)
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub

        Protected Overrides Sub OnDeleted()
            MyBase.OnDeleted()
        End Sub

        Private _id As Guid
        <Key(AutoGenerate:=True)> _
        Public Property ID() As Guid
            Get
                Return _id
            End Get
            Set(ByVal value As Guid)
                SetPropertyValue(Of Guid)("ID", _id, value)
            End Set
        End Property

        Private _isAllDay As Boolean
        Public Property IsAllDay() As Boolean
            Get
                Return _isAllDay
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsAllDay", _isAllDay, value)
            End Set
        End Property

        Private _description As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", _description, value)
            End Set
        End Property

        Private _notes As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", _notes, value)
            End Set
        End Property

        Private _label As Integer
        Public Property Label() As Integer
            Get
                Return _label
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Label", _label, value)
            End Set
        End Property

        Private _location As String
        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Location", _location, value)
            End Set
        End Property

        Private _recurrence As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Recurrence() As String
            Get
                Return _recurrence
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Recurrence", _recurrence, value)
            End Set
        End Property

        Private _reminder As String
        <Size(SizeAttribute.Unlimited)> _
        Public Property Reminder() As String
            Get
                Return _reminder
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Reminder", _reminder, value)
            End Set
        End Property

        <NonPersistent()> _
        Public Property IsCompleted() As Boolean
            Get
                Return CompletionStatus < 0
            End Get
            Set(ByVal value As Boolean)
                CompletionStatus = If(value, CInt(Fix(CompletionCode.Completed)), CInt(Fix(CompletionCode.NotStarted)))
            End Set
        End Property

        Private _completionStatus As Integer
        Public Property CompletionStatus() As Integer
            Get
                Return _completionStatus
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CompletionStatus", _completionStatus, value)
            End Set
        End Property

        Private _start As DateTime
        Public Property Start() As DateTime
            Get
                Return _start
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Start", _start, value)
            End Set
        End Property

        Private _finish As DateTime
        Public Property Finish() As DateTime
            Get
                Return _finish
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Finish", _finish, value)
            End Set
        End Property

        Private _status As Integer
        Public Property Status() As Integer
            Get
                Return _status
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Status", _status, value)
            End Set
        End Property

        Private _subject As String
        Public Property Subject() As String
            Get
                Return _subject
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Subject", _subject, value)
            End Set
        End Property

        Private _itemType As Integer
        Public Property ItemType() As Integer
            Get
                Return _itemType
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ItemType", _itemType, value)
            End Set
        End Property

        Private _appointmentType As Integer
        Public Property AppointmentType() As Integer
            Get
                Return _appointmentType
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("AppointmentType", _appointmentType, value)
            End Set
        End Property

#If RESOURCE_SHARING Then
		<Association("Appointments-Resources", UseAssociationNameAsIntermediateTableName := True)> _
		Public ReadOnly Property Resources() As XPCollection(Of Resource)
			Get
				Return GetCollection(Of Resource)("Resources")
			End Get
		End Property
#Else
        Private _resource As Resource
        <Association("Appointments-Resources", UseAssociationNameAsIntermediateTableName:=True)> _
        Public Property Resource() As Resource
            Get
                Return _resource
            End Get
            Set(ByVal value As Resource)
                SetPropertyValue(Of Resource)("Resource", _resource, value)
            End Set
        End Property

        <Visible(), NonPersistent()> _
        Public Property AssignedTo() As Guid?
            Get
                Return If(_resource IsNot Nothing, New Guid?(_resource.ID), Nothing)
            End Get
            Set(ByVal value? As Guid)
                Resource = Me.Session.GetObjectByKey(Of Resource)(value)
            End Set
        End Property
#End If

#If RESOURCES Then
#If (Not WIN) Then
		<NonPersistent(), Visible> _
		Public Property Resources() As String
#Else
		<NonPersistent()> _
		Public Property Resources() As String
#End If
			Get
'INSTANT VB NOTE: The local variable resources was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
				Dim resources_Renamed As New ResourceIdCollection()

				For i As Integer = 0 To Participants.Count - 1
					resources_Renamed.Add(Participants(i).ID)
				Next i

				Return New AppointmentResourceIdCollectionXmlPersistenceHelper(resources_Renamed).ToXml()
			End Get
			Set(ByVal value As String)
'INSTANT VB NOTE: The local variable resources was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
				Dim resources_Renamed As New ResourceIdCollection()

				If (Not String.IsNullOrEmpty(value)) Then
					resources_Renamed = AppointmentResourceIdCollectionXmlPersistenceHelper.ObjectFromXml(resources_Renamed, value)
				End If

				Participants.SuspendChangedEvents()
				Try
					Do While Participants.Count > 0
						Participants.Remove(Participants(0))
					Loop

					For i As Integer = 0 To resources_Renamed.Count - 1
						Dim resource As Participant = Me.Session.GetObjectByKey(Of Participant)(resources_Renamed(i))
						If resource IsNot Nothing Then
							Participants.Add(resource)
						End If
					Next i

				Finally
					Participants.ResumeChangedEvents()
				End Try
			End Set
		End Property
#End If

    End Class

End Namespace
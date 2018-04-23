Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraScheduler.Xml

Namespace DevExpress.Calendar.Model
	Partial Public Class Appointment

		Public Function Clone(ByVal kind As DateTimeKind) As Appointment

			Dim obj As Appointment = CreateAppointment(ID, IsAllDay, Label, CompletionStatus,If(kind = DateTimeKind.Local, (Start.ToLocalTime()), (If(kind = DateTimeKind.Utc, Start.ToUniversalTime(), Start))),If(kind = DateTimeKind.Local, (Finish.ToLocalTime()), (If(kind = DateTimeKind.Utc, Finish.ToUniversalTime(), Finish))), Status, ItemType, AppointmentType)

			obj.Resource = Resource
			obj.AssignedTo = AssignedTo
			obj.Notes = Notes
			obj.Subject = Subject
			obj.Description = Description
			obj.IsAllDay = IsAllDay
			obj.Recurrence = Recurrence
			obj.Reminder = Reminder

'            
'#pragma warning disable 618
'
'            switch (kind) {
'                case DateTimeKind.Local:
'
'                    if (!string.IsNullOrEmpty(Reminder)) {
'                        using (XtraScheduler.Appointment apt = new XtraScheduler.Appointment()) {
'
'                            XtraScheduler.Reminder reminder = apt.CreateNewReminder();
'
'                            reminder.FromXml(this.Reminder);
'
'                            reminder.AlertTime = apt.Reminder.AlertTime.ToLocalTime();
'
'                            obj.Reminder = reminder.ToXml();
'
'                        }
'                    }
'
'                    break;
'
'                case DateTimeKind.Utc:
'
'                    if (!string.IsNullOrEmpty(this.Reminder)) {
'                        
'                        using (XtraScheduler.Appointment apt = new XtraScheduler.Appointment()) {
'
'                            apt.Start = this.Start;
'                            apt.End = this.Finish;
'
'                            XtraScheduler.Reminder reminder = apt.CreateNewReminder();
'
'                            reminder.FromXml(this.Reminder);
'
'                            reminder.AlertTime = reminder.AlertTime.ToUniversalTime();
'
'                            obj.Reminder = reminder.ToXml();
'
'                        }
'
'                    }
'
'                     break;
'
'                default:
'
'                    obj.Reminder = Reminder;
'                    break;
'            }
'
'#pragma warning restore 618
'            

			Return obj

		End Function

	End Class
End Namespace

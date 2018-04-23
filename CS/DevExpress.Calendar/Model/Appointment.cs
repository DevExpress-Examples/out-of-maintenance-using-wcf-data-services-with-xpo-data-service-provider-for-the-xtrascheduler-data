using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler.Xml;

namespace DevExpress.Calendar.Model {
    public partial class Appointment {

        public Appointment Clone(DateTimeKind kind) {
            
            Appointment obj = CreateAppointment(
                            ID,
                            IsAllDay,
                            Label,
                            CompletionStatus,
                            kind == DateTimeKind.Local ? (Start.ToLocalTime()) : (kind == DateTimeKind.Utc ? Start.ToUniversalTime() : Start),
                            kind == DateTimeKind.Local ? (Finish.ToLocalTime()) : (kind == DateTimeKind.Utc ? Finish.ToUniversalTime() : Finish),
                            Status,
                            ItemType,
                            AppointmentType);

            obj.Resource = Resource;
            obj.AssignedTo = AssignedTo;
            obj.Notes = Notes;
            obj.Subject = Subject;
            obj.Description = Description;
            obj.IsAllDay = IsAllDay;
            obj.Recurrence = Recurrence;
            obj.Reminder = Reminder;

            /*
#pragma warning disable 618

            switch (kind) {
                case DateTimeKind.Local:

                    if (!string.IsNullOrEmpty(Reminder)) {
                        using (XtraScheduler.Appointment apt = new XtraScheduler.Appointment()) {

                            XtraScheduler.Reminder reminder = apt.CreateNewReminder();

                            reminder.FromXml(this.Reminder);

                            reminder.AlertTime = apt.Reminder.AlertTime.ToLocalTime();

                            obj.Reminder = reminder.ToXml();

                        }
                    }

                    break;

                case DateTimeKind.Utc:

                    if (!string.IsNullOrEmpty(this.Reminder)) {
                        
                        using (XtraScheduler.Appointment apt = new XtraScheduler.Appointment()) {

                            apt.Start = this.Start;
                            apt.End = this.Finish;

                            XtraScheduler.Reminder reminder = apt.CreateNewReminder();

                            reminder.FromXml(this.Reminder);

                            reminder.AlertTime = reminder.AlertTime.ToUniversalTime();

                            obj.Reminder = reminder.ToXml();

                        }

                    }

                     break;

                default:

                    obj.Reminder = Reminder;
                    break;
            }

#pragma warning restore 618
            */

            return obj;

        }

    }
}

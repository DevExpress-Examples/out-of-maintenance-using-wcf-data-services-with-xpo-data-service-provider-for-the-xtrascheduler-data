namespace DevExpress.Calendar.Parts {
    using System;
    using System.Diagnostics;
    using DevExpress.Calendar.Model;
    
    public class AppointmentEventArgs : EventArgs {
        Appointment _appointment;
        public Appointment Appointment {
            get {
                return _appointment;
            }
        }

        public AppointmentEventArgs(Appointment appointment) {
            Debug.Assert(appointment != null);
            _appointment = appointment;
        }
    }
}

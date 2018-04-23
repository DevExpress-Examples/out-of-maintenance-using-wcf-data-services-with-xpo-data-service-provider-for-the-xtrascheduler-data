namespace DevExpress.Calendar.Model {
    using System;
    
    public partial class Appointment {

        /// <summary>
        /// CompletionCode
        /// </summary>
        public enum CompletionCode : int {
            NotStarted = 0,
            InProgress = 1,
            Completed = -1, 
            Canceled = -2,
        }

        /// <summary>
        /// ItemCode
        /// </summary>
        public enum ItemCode : int {
            Appointment = 0,
            Meeting = 1,
            Event = 2,
            Task = 3,
            Project = 4,
        }        
    }
}
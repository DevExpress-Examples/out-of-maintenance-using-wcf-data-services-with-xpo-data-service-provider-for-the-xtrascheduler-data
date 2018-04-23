using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.Calendar {
    public interface ICalendar {
        void Create(Model.Appointment.ItemCode itemType);
    }
}

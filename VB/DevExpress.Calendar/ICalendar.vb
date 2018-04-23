Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DevExpress.Calendar
	Public Interface ICalendar
		Sub Create(ByVal itemType As Model.Appointment.ItemCode)
	End Interface
End Namespace

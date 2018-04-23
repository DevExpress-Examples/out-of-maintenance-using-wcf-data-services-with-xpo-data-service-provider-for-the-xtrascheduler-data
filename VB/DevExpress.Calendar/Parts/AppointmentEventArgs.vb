Imports Microsoft.VisualBasic
	Imports System
	Imports System.Diagnostics
	Imports DevExpress.Calendar.Model
Namespace DevExpress.Calendar.Parts

	Public Class AppointmentEventArgs
		Inherits EventArgs
		Private _appointment As Appointment
		Public ReadOnly Property Appointment() As Appointment
			Get
				Return _appointment
			End Get
		End Property

		Public Sub New(ByVal appointment As Appointment)
			Debug.Assert(appointment IsNot Nothing)
			_appointment = appointment
		End Sub
	End Class
End Namespace

Imports Microsoft.VisualBasic
	Imports System
Namespace DevExpress.Calendar.Model

	Partial Public Class Appointment

		''' <summary>
		''' CompletionCode
		''' </summary>
		Public Enum CompletionCode As Integer
			NotStarted = 0
			InProgress = 1
			Completed = -1
			Canceled = -2
		End Enum

		''' <summary>
		''' ItemCode
		''' </summary>
		Public Enum ItemCode As Integer
			Appointment = 0
			Meeting = 1
			[Event] = 2
			Task = 3
			Project = 4
		End Enum
	End Class
End Namespace
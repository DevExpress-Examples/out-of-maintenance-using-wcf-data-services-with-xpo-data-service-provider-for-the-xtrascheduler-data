Imports Microsoft.VisualBasic
	Imports System
	Imports System.Windows.Forms
Namespace DevExpress.Calendar

	Public NotInheritable Class Program
		Private Shared _service As New Uri("http://localhost:60995/Service.svc")

		Private Sub New()
		End Sub
		Public Shared ReadOnly Property Service() As Uri
			Get
				Return _service
			End Get
		End Property

		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)

			DevExpress.UserSkins.BonusSkins.Register()
			DevExpress.UserSkins.OfficeSkins.Register()

			Application.Run(New Client())
		End Sub
	End Class
End Namespace
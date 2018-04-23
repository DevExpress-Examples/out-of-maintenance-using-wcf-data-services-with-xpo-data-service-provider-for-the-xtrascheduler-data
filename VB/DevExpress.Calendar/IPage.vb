Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars

Namespace DevExpress.Calendar
	Public Interface IPage
		Sub Page_Load(ByVal e As PageLoadEventArgs)
		Sub Page_Invalidate()
	End Interface
End Namespace

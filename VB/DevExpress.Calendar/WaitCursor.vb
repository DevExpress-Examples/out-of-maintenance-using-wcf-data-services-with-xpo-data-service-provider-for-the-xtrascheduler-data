Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Namespace DevExpress.Calendar
	Public Class WaitCursor
		Implements IDisposable

#If WIN Then
		Private _cursor As Cursor
#End If
		Private _disposed As Boolean = False

		Public Sub New()
#If WIN Then
			_cursor = Cursor.Current
			Cursor.Current = Cursors.WaitCursor
#End If
		End Sub

		Public Sub Dispose() Implements IDisposable.Dispose
			If (Not _disposed) Then
				_disposed = True
#If WIN Then
				Cursor.Current = _cursor
#End If
			End If
		End Sub
	End Class
End Namespace
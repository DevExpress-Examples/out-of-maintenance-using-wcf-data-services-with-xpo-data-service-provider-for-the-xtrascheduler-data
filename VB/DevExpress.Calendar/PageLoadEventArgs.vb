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
	Public Class PageLoadEventArgs
		Public Sub New(ByVal typeInfo As Type, ByVal shouldLoadData As Boolean, ByVal state As Object)
			Me._typeInfo = typeInfo
			Me._shouldLoadData = shouldLoadData
			Me._state = state
		End Sub

		Public Sub New(ByVal typeInfo As Type, ByVal state As Object)
			Me._typeInfo = typeInfo
			Me._shouldLoadData = True
			Me._state = state
		End Sub

		Private _typeInfo As Type
		Public ReadOnly Property TypeInfo() As Type
			Get
				Return Me._typeInfo
			End Get
		End Property

		Private _state As Object
		Public ReadOnly Property State() As Object
			Get
				Return Me._state
			End Get
		End Property

		Private _shouldLoadData As Boolean = True
		Public Property ShouldLoadData() As Boolean
			Get
				Return _shouldLoadData
			End Get
			Set(ByVal value As Boolean)
				_shouldLoadData = False
			End Set
		End Property
	End Class
End Namespace

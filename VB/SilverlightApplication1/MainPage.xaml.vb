Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports System.Windows.Media.Imaging

Namespace SilverlightApplication1
	Partial Public Class MainPage
		Inherits UserControl
		Private dataSource As ObservableCollection(Of MyObject)

		Public Sub New()
			InitializeComponent()
			dataSource = New ObservableCollection(Of MyObject)()
			dataSource.Add(New MyObject("cut"))
			dataSource.Add(New MyObject("copy"))
			dataSource.Add(New MyObject("paste"))
			dataSource.Add(New MyObject("delete"))
			gridControl1.ItemsSource = dataSource
		End Sub

		Private Sub gridControl1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.GridColumnDataEventArgs)
			If e.Column.FieldName = "IconUnbound" Then
				If e.IsGetData Then
					Dim row As MyObject = dataSource(e.ListSourceRowIndex)
					Dim resourceName As String = GetResourceName(row.Action)
					e.Value = GetImage(resourceName)
				End If
			End If
		End Sub
		Private Function GetImage(ByVal resourceName As String) As BitmapImage
			Dim uri As New Uri(App.Current.Host.Source, "Icons/" & resourceName)
			Return New BitmapImage(uri)
		End Function
		Private Function GetResourceName(ByVal action As String) As String
			Select Case action
				Case "copy"
					Return "copy32x32.png"
				Case "cut"
					Return "cut32x32.png"
				Case "delete"
					Return "delete32x32.png"
				Case "paste"
					Return "paste32x32.png"
			End Select
			Return String.Empty
		End Function


	End Class
	Public Class MyObject
		Public Sub New()
		End Sub
		Public Sub New(ByVal action As String)
			Action = action
		End Sub
		Private privateAction As String
		Public Property Action() As String
			Get
				Return privateAction
			End Get
			Set(ByVal value As String)
				privateAction = value
			End Set
		End Property
	End Class

End Namespace

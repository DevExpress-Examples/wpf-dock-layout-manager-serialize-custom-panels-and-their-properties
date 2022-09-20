Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Serialization
Imports DevExpress.Xpf.Docking
Imports System.Windows

Namespace DXWpfApplication
	Partial Public Class MainWindow
		Inherits ThemedWindow

		Private Const LayoutPath As String = "layout.xml"
		Private Const App As String = "DXWpfApplication"
		'
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
			panel2.Prop1 = 117
			MyCustomPanel.SetProp2(panel3, 287)
			DXSerializer.Serialize(Me, LayoutPath, App, New DXOptionsLayout() With {.AcceptNestedObjects = AcceptNestedObjects.VisualTreeOnly})
		End Sub
		Private Sub ButtonRestore_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
			panel2.Prop1 = 0
			MyCustomPanel.SetProp2(panel3, 0)
			DXSerializer.Deserialize(Me, LayoutPath, App, New DXOptionsLayout() With {.AcceptNestedObjects = AcceptNestedObjects.VisualTreeOnly})
		End Sub
	End Class
	Friend Class TestData
		Public Property Text() As String
		Public Property Number() As Integer
	End Class
	'
	Friend Class MyCustomPanel
		Inherits LayoutPanel

		Public Shared ReadOnly Prop2Property As DependencyProperty
		Shared Sub New()
			Prop2Property = DependencyProperty.RegisterAttached("Prop2", GetType(Integer), GetType(MyCustomPanel), New PropertyMetadata(0))
		End Sub
		'
		<DevExpress.Utils.Serializing.XtraSerializableProperty>
		Public Shared Function GetProp2(ByVal obj As DependencyObject) As Integer
			Return DirectCast(obj.GetValue(Prop2Property), Integer)
		End Function
		Public Shared Sub SetProp2(ByVal obj As DependencyObject, ByVal value As Integer)
			obj.SetValue(Prop2Property, value)
		End Sub
		<DevExpress.Utils.Serializing.XtraSerializableProperty>
		Public Property Prop1() As Integer
	End Class
End Namespace
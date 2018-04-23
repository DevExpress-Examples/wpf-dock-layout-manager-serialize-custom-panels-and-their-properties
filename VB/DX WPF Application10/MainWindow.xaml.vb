Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Serialization
Imports DevExpress.Xpf.Docking
Imports System.Windows

Namespace DXWpfApplication
	Partial Public Class MainWindow
		Inherits DXWindow
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
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
	End Class
	'
	Friend Class MyCustomPanel
		Inherits LayoutPanel
		Public Shared ReadOnly Prop2Property As DependencyProperty
		Shared Sub New()
			Prop2Property = DependencyProperty.RegisterAttached("Prop2", GetType(Integer), GetType(MyCustomPanel), New PropertyMetadata(0))
		End Sub
		'
		<DevExpress.Utils.Serializing.XtraSerializableProperty> _
		Public Shared Function GetProp2(ByVal obj As DependencyObject) As Integer
			Return CInt(Fix(obj.GetValue(Prop2Property)))
		End Function
		Public Shared Sub SetProp2(ByVal obj As DependencyObject, ByVal value As Integer)
			obj.SetValue(Prop2Property, value)
		End Sub
		Private privateProp1 As Integer
		<DevExpress.Utils.Serializing.XtraSerializableProperty> _
		Public Property Prop1() As Integer
			Get
				Return privateProp1
			End Get
			Set(ByVal value As Integer)
				privateProp1 = value
			End Set
		End Property
	End Class
End Namespace
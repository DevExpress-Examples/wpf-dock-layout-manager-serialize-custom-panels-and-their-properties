Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Serialization
Imports DevExpress.Xpf.Docking
Imports System.Windows

Namespace DXWpfApplication

    Public Partial Class MainWindow
        Inherits ThemedWindow

        Const LayoutPath As String = "layout.xml"

        Const App As String = "DXWpfApplication"

        '
        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ButtonSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.panel2.Prop1 = 117
            MyCustomPanel.SetProp2(Me.panel3, 287)
            Call DXSerializer.Serialize(Me, LayoutPath, App, New DXOptionsLayout() With {.AcceptNestedObjects = AcceptNestedObjects.VisualTreeOnly})
        End Sub

        Private Sub ButtonRestore_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.panel2.Prop1 = 0
            MyCustomPanel.SetProp2(Me.panel3, 0)
            Call DXSerializer.Deserialize(Me, LayoutPath, App, New DXOptionsLayout() With {.AcceptNestedObjects = AcceptNestedObjects.VisualTreeOnly})
        End Sub
    End Class

    Friend Class TestData

        Public Property Text As String

        Public Property Number As Integer
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
            Return CInt(obj.GetValue(Prop2Property))
        End Function

        Public Shared Sub SetProp2(ByVal obj As DependencyObject, ByVal value As Integer)
            obj.SetValue(Prop2Property, value)
        End Sub

        <DevExpress.Utils.Serializing.XtraSerializableProperty>
        Public Property Prop1 As Integer
    End Class
End Namespace

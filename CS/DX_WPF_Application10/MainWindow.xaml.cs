using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Docking;
using System.Windows;

namespace DXWpfApplication {
    public partial class MainWindow : ThemedWindow {
        const string LayoutPath = "layout.xml";
        const string App = "DXWpfApplication";
        //
        public MainWindow() {
            InitializeComponent();
        }
        void ButtonSave_Click(object sender, System.Windows.RoutedEventArgs e) {
            panel2.Prop1 = 117;
            MyCustomPanel.SetProp2(panel3, 287);
            DXSerializer.Serialize(this, LayoutPath, App,
                    new DXOptionsLayout() { AcceptNestedObjects = AcceptNestedObjects.VisualTreeOnly }
                );
        }
        void ButtonRestore_Click(object sender, System.Windows.RoutedEventArgs e) {
            panel2.Prop1 = 0;
            MyCustomPanel.SetProp2(panel3, 0);
            DXSerializer.Deserialize(this, LayoutPath, App,
                    new DXOptionsLayout() { AcceptNestedObjects = AcceptNestedObjects.VisualTreeOnly }
                );
        }
    }
    class TestData {
        public string Text { get; set; }
        public int Number { get; set; }
    }
    //
    class MyCustomPanel : LayoutPanel {
        public static readonly DependencyProperty Prop2Property;
        static MyCustomPanel() {
            Prop2Property = DependencyProperty.RegisterAttached("Prop2", typeof(int), typeof(MyCustomPanel), new PropertyMetadata(0));
        }
        //
        [DevExpress.Utils.Serializing.XtraSerializableProperty]
        public static int GetProp2(DependencyObject obj) {
            return (int)obj.GetValue(Prop2Property);
        }
        public static void SetProp2(DependencyObject obj, int value) {
            obj.SetValue(Prop2Property, value);
        }
        [DevExpress.Utils.Serializing.XtraSerializableProperty]
        public int Prop1 { get; set; }
    }
}
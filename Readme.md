<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643856/10.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2324)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomSerialization.cs](./CS/DX WPF Application10/CustomSerialization.cs) (VB: [CustomSerialization.vb](./VB/DX WPF Application10/CustomSerialization.vb))
* [MainWindow.xaml](./CS/DX WPF Application10/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DX WPF Application10/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DX WPF Application10/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DX WPF Application10/MainWindow.xaml.vb))
<!-- default file list end -->
# How to serialize custom panels and their properties


<p>This example demonstrates how to save and restore custom panels and it's properties.</p><p>In this example, we have a custom panel, derived from the LayoutPanel:<br />


```C#
<newline/>
   class MyCustomPanel : LayoutPanel {<newline/>
    ...<newline/>
   }<newline/>

```

</p><p>To mark some panel's properties as serializable, we can apply the XtraSerializablePropertyAttribute to the setters of corresponding properties.<br />
Note that the target properties can be a dependency or an attached type:<br />


```C#
<newline/>
...<newline/>
        [DevExpress.Utils.Serializing.XtraSerializableProperty]<newline/>
        public int Prop1 { get; set; }<newline/>
...<newline/>
        [DevExpress.Utils.Serializing.XtraSerializableProperty]<newline/>
        public static int GetProp2(DependencyObject obj) {<newline/>
            return (int)obj.GetValue(Prop2Property);<newline/>
        }<newline/>
...<newline/>

```

</p><p>The CustomSerializationController class extends the DockLayoutManager serialization logic when you need to create<br />
new panels via layout restoration. <br />
To inject the CustomSerializationController class in the DockLayoutManager we override the CreateSerializationController() method.</p>

<br/>



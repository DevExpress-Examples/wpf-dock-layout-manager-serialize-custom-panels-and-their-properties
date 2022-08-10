<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643856/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2324)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Dock Layout Manager - Serialize Custom Panels and Their Properties

This example saves and restores custom panels and its properties.

<img src="https://user-images.githubusercontent.com/12169834/175375397-b8ce5ea2-193e-42aa-b975-6c6a2819d7ec.png" width=800px/>

This example contains a custom panel derived from the [LayoutPanel](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.LayoutPanel):


```C#
class MyCustomPanel : LayoutPanel {
   ...
}

```

To mark some panel properties as serializable, you can apply the `XtraSerializablePropertyAttribute` to the setters of corresponding properties. Target properties can be a dependency or an attached type:


```C#
[DevExpress.Utils.Serializing.XtraSerializableProperty]
public int Prop1 { get; set; }
...
[DevExpress.Utils.Serializing.XtraSerializableProperty]
public static int GetProp2(DependencyObject obj) {
   return (int)obj.GetValue(Prop2Property);
}
```

The **CustomSerializationController** class extends the [DockLayoutManager](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.DockLayoutManager) serialization logic when you need to create new panels when you restore a layout.
   
To inject the **CustomSerializationController** class in the [DockLayoutManager](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.DockLayoutManager), you can override the `CreateSerializationController()` method.

<!-- default file list -->
## Files to Look At

* [CustomSerialization.cs](./CS/DX_WPF_Application10/CustomSerialization.cs) (VB: [CustomSerialization.vb](./VB/DX_WPF_Application10/CustomSerialization.vb))
* [MainWindow.xaml](./CS/DX_WPF_Application10/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DX_WPF_Application10/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DX_WPF_Application10/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DX_WPF_Application10/MainWindow.xaml.vb))
<!-- default file list end -->


## Documentation
- [Save and Restore the Layout of Dock Panels and Controls](https://docs.devexpress.com/WPF/7059/controls-and-libraries/layout-management/dock-windows/miscellaneous/saving-and-restoring-the-layout-of-dock-panels-and-controls)
- [Save/Restore Control Layout Overview](https://docs.devexpress.com/WPF/7391/common-concepts/save-and-restore-layouts)

## More Examples

- [WPF Dock Layout Manager - Save and Restore Settings of All Controls That Are Present in the UI](https://github.com/DevExpress-Examples/wpf-dock-layout-manager-save-and-restore-settings-of-all-controls-that-are-present-in-the-ui)
- [WPF Dock Layout Manager - Save and Restore the DockLayoutManager's Layout](https://github.com/DevExpress-Examples/wpf-dock-layout-manager-save-and-restore-the-dock-layout-managers-layout)
- [WPF Dock Layout Manager - Serialize a Particular Panel's Layout](https://github.com/DevExpress-Examples/wpf-dock-layout-manager-serialize-a-particular-panels-layout)

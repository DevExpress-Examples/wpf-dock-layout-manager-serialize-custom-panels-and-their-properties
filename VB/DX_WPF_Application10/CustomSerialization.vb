Imports DevExpress.Utils.Serializing.Helpers
Imports DevExpress.Xpf.Docking

Namespace DXWpfApplication
	Friend Class MyDockLayoutManager
		Inherits DockLayoutManager

		Protected Overrides Function CreateSerializationController() As ISerializationController
			Return New CustomSerializationController(Me)
		End Function
		Protected Friend Overridable Function CreateCustomPanel() As MyCustomPanel
			Return New MyCustomPanel()
		End Function
	End Class
	Friend Class CustomSerializationController
		Inherits SerializationController

		Public Sub New(ByVal container As DockLayoutManager)
			MyBase.New(container)
		End Sub
		Protected Overrides Function CreateItemByType(ByVal info As XtraPropertyInfo, ByVal typeStr As String) As BaseLayoutItem
			If typeStr = GetType(MyCustomPanel).Name Then
				Return DirectCast(Container, MyDockLayoutManager).CreateCustomPanel()
			End If
			Return MyBase.CreateItemByType(info, typeStr)
		End Function
	End Class
End Namespace
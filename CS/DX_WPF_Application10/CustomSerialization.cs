using DevExpress.Utils.Serializing.Helpers;
using DevExpress.Xpf.Docking;

namespace DXWpfApplication {
    class MyDockLayoutManager : DockLayoutManager {
        protected override ISerializationController CreateSerializationController() {
            return new CustomSerializationController(this);
        }
        protected internal virtual MyCustomPanel CreateCustomPanel() {
            return new MyCustomPanel();
        }
    }
    class CustomSerializationController : SerializationController {
        public CustomSerializationController(DockLayoutManager container)
            : base(container) {
        }
        protected override BaseLayoutItem CreateItemByType(XtraPropertyInfo info, string typeStr) {
            if(typeStr == typeof(MyCustomPanel).Name)
                return ((MyDockLayoutManager)Container).CreateCustomPanel();
            return base.CreateItemByType(info, typeStr);
        }
    }
}
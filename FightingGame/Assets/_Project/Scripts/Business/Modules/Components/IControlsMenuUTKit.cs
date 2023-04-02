namespace Core.Business
{
    public interface IControlsMenuUTKit : IBaseModule
    { }

    public class ControlsMenuUTKitModel : IModuleContextModel
    {
        public string ViewId { get; set; }

        public IBaseModule Module { get; set; }

        public ControlsMenuUTKitModel()
        { }

        public ControlsMenuUTKitModel(string viewId)
        {
            ViewId = viewId;
        }

        public IModuleContextModel Clone()
        {
            return new ControlsMenuUTKitModel(ViewId);
        }

        public void Refresh()
        {
            Module.Refresh(this);
        }

        public void CustomRefresh(string comparer)
        { }
    }
}
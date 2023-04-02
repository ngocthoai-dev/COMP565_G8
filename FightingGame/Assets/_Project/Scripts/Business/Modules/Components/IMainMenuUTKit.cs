namespace Core.Business
{
    public interface IMainMenuUTKit : IBaseModule
    { }

    public class MainMenuUTKitModel : IModuleContextModel
    {
        public string ViewId { get; set; }

        public IBaseModule Module { get; set; }

        public MainMenuUTKitModel()
        { }

        public MainMenuUTKitModel(string viewId)
        {
            ViewId = viewId;
        }

        public IModuleContextModel Clone()
        {
            return new MainMenuUTKitModel(ViewId);
        }

        public void Refresh()
        {
            Module.Refresh(this);
        }

        public void CustomRefresh(string comparer)
        { }
    }
}
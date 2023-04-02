using Core.Business;

namespace Core.View
{
    public class ControlsMenuUTKitScript : IBaseScript
    {
        public BaseViewConfig GetConfig()
        {
            return new BaseViewConfig(
                bundle: "Assets/_Project/Bundles/Prefabs/Views/UIElements/ControlsMenu/ControlsScene.prefab",
                uiType: UIType.UIToolkit
            )
            {
                Config = ""
            };
        }
    }
}
using Core.Business;

namespace Core.View
{
    public class MainMenuUTKitScript : IBaseScript
    {
        public BaseViewConfig GetConfig()
        {
            return new BaseViewConfig(
                bundle: "Assets/_Project/Bundles/Prefabs/Views/UIElements/MainMenu/StartScene.prefab",
                uiType: UIType.UIToolkit
            )
            {
                Config = ""
            };
        }
    }
}
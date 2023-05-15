using Assets.CodeBase.Services;
using Assets.CodeBase.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.CodeBase.Factory
{
    public class HUDFactory : IHUDFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly UIHUDController _uiHUDController;
        private UIDocument _hud;
        public UIDocument HUD => _hud;

        public HUDFactory(IStaticDataService staticDataService, UIHUDController uiHUDController)
        {
            _staticDataService = staticDataService;
            _uiHUDController = uiHUDController;
        }

        public UIDocument Create()
        {
            var hudGameObject = new GameObject("HUD");
            var document = hudGameObject.AddComponent<UIDocument>();
            _hud = document;
            document.visualTreeAsset = _staticDataService.HUD;
            document.panelSettings = _staticDataService.UIPanelSettings;
            _uiHUDController.SetDocument(_hud);
            return document;
        }
    }
}

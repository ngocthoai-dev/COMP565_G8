using Core.Business;
using Core.Gameplay;
using Core.SO;
using Core.Utility;
using Cysharp.Threading.Tasks;
using Network.UnityGGPO;
using Shared.Extension;
using System.Collections.Generic;
using UnityEngine;
using UnityGGPO;
using Zenject;
using System.Linq;
using Core.View;

namespace Core.GGPO
{
    public class NetworkManager : GameManager
    {
        [SerializeField] private bool isDebugBattle = false;
        private IBundleLoader _bundleLoader;

        [SerializeField] private MapConfig _mapConfig;
        [SerializeField][DebugOnly] private CharacterConfigSO[] _charConfigs;

        public MapConfig MapConfig { get; private set; }
        public CharacterConfigSO[] CharConfigs { get; private set; }

        [Inject]
        public void Construct(
            [Inject(Id = BundleLoaderName.Addressable)]
            IBundleLoader bundleLoader)
        {
            _bundleLoader = bundleLoader;
            LoadAssets();
        }

        private async void LoadAssets()
        {
            if (isDebugBattle)
            {
                _charConfigs = new CharacterConfigSO[2];
                _charConfigs[0] = await _bundleLoader.LoadAssetAsync<CharacterConfigSO>("Assets/_Project/Bundles/ScriptableObjects/Character/FourTails/CharacterConfig.asset");
                _charConfigs[1] = await _bundleLoader.LoadAssetAsync<CharacterConfigSO>("Assets/_Project/Bundles/ScriptableObjects/Character/FourTails/CharacterConfig 1.asset");
                PreStartGame(_mapConfig, _charConfigs).StartLocalGame();
            }
        }

        public NetworkManager PreStartGame(MapConfig mapConfig, CharacterConfigSO[] characterConfigSOs)
        {
            MapConfig = mapConfig;
            CharConfigs = characterConfigSOs.Select(ele => ele.ApplyStats().Clone()).ToArray();
            InputController.Instance.PlayerInput.enabled = true;
            return this;
        }

        public NetworkManager PreStartGame(int mapIdx, CharacterConfigSO[] characterConfigSOs)
        {
            MapConfig = FindObjectsOfType<MapConfig>()[mapIdx];
            CharConfigs = characterConfigSOs.Select(ele => ele.ApplyStats().Clone()).ToArray();

            if (CharConfigs[0].CharacterName == CharConfigs[1].CharacterName)
                CharConfigs[1].Color = new Color(0x00, 0xFF, 0x23);
            else
                CharConfigs[1].Color = Color.white;

            return this;
        }

        public override void StartLocalGame()
        {
            StartGame(new LocalRunner(new NetworkGame(MapConfig, CharConfigs)));
        }

        public override void StartGGPOGame(IPerfUpdate perfPanel, IList<Connections> connections, int playerIndex)
        {
            var game = new GGPORunner(GetType().Name.ToString(), new NetworkGame(MapConfig, CharConfigs), perfPanel);
            game.Init(connections, playerIndex);
            StartGame(game);
        }
    }
}
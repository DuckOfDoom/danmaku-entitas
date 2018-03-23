using DuckOfDoom.Danmaku.UI.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace DuckOfDoom.Danmaku
{
    public class UIController : CommonController
    {
        [SerializeField] private Text _playerHealthText;

        protected override void SetUp()
        {
            var gameplayContext = Contexts.sharedInstance.gameplay;
            _updateSystems.Add(new PlayerStatsUISystem(
                gameplayContext,
                health => _playerHealthText.text = string.Format("PlayerHealth: {0}", Mathf.RoundToInt(health).ToString())
            ));
        }
    }
}
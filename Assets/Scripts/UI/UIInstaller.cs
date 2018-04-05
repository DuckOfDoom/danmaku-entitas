using UnityEngine;
using UnityEngine.UI;

namespace DuckOfDoom.Danmaku.UI
{
    public class UIInstaller : EcsInstaller
    {
        [SerializeField] private Text _playerHealthText;

	    public override void InstallBindings()
	    {
		    Container.Bind<GameplayContext>().FromInstance(Contexts.sharedInstance.gameplay);
		    Container.Bind<SetPlayerHealth>()
			    .FromInstance(health =>
			    {
				    _playerHealthText.text = string.Format("PlayerHealth: {0}", Mathf.RoundToInt(health).ToString());
			    });
	        
	        InstallUpdateSystem<PlayerStatsUISystem>();

		    base.InstallBindings();
	    }
    }
}
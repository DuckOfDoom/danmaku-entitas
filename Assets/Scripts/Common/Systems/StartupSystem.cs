using Entitas;
using UnityEngine.SceneManagement;

namespace DuckOfDoom.Danmaku
{
    public class StartupSystem : IInitializeSystem
    {
        public void Initialize()
        {
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
    }
}

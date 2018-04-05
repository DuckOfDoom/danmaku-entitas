using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuckOfDoom.Danmaku
{
	/// <summary>
	/// 	EntryPoint
	/// </summary>
	public class Main : MonoBehaviour
	{
		public void Awake()
		{
            SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
		}
	}
}

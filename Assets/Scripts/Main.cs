using UnityEngine;

namespace DuckOfDoom.Danmaku
{
	/// <summary>
	/// 	EntryPoint
	/// </summary>
	public class Main : MonoBehaviour
	{
		public void Awake()
		{
			new StartupSystem().Initialize();
		}
	}
}

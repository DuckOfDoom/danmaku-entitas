using JetBrains.Annotations;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
	/// <summary>
	/// 	EntryPoint
	/// </summary>
	public class Main : MonoBehaviour
	{
		[UsedImplicitly] 
		public void Awake()
		{
			new StartupSystem().Initialize();
		}
	}
}

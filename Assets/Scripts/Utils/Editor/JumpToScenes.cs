using UnityEditor;
using UnityEditor.SceneManagement;

public class JumpToScenes
{
	[MenuItem("Quick/Open Scene: Main %&#m", false, 0)]
	public static void OpenSceneHUD()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Main.unity");
	}
	
	[MenuItem("Quick/Open Scene: Gameplay %&#g", false, 0)]
	public static void OpenSceneGameplay()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Gameplay.unity");
	}
	
	[MenuItem("Quick/Open Scene: Gameplay %&#u", false, 0)]
	public static void OpenSceneUI()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/UI.unity");
	}
}
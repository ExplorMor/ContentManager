using UnityEngine;
using UnityEditor;
using System.Collections;

public class ContentManagerPanel : EditorWindow 
{
	private string prototypePath = "ContentManagementPlatform/BaseCard";
	private string cardPath = "ContentManagementPlatform/Export/";
	public GameObject newCardPrefab;
	
	public string cardString;

	[MenuItem ("Window/ContentManager")]
	static void Init () 
	{
		ContentManagerPanel window = (ContentManagerPanel)EditorWindow.GetWindow (typeof (ContentManagerPanel));
		window.Show();
	}
	
	void OnGUI () 
	{
		//GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		cardString = EditorGUILayout.TextField ("Card Name", cardString);

		if(GUILayout.Button ("Create New Card"))
		{
			if(newCardPrefab != null)
			{
				GameObject.DestroyImmediate(newCardPrefab);
			}

			newCardPrefab = GameObject.Instantiate(Resources.Load (prototypePath)) as GameObject;
			newCardPrefab.name = cardString;
		}



		if(GUILayout.Button("Save as Prefab"))
		{
			PrefabUtility.CreatePrefab("Assets/Resources/"+cardPath+cardString+".prefab", newCardPrefab);
		}
	}
}

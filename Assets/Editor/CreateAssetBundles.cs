using UnityEditor;
using UnityEngine;
using System.Collections;

public class CreateAssetBundles
{
    [MenuItem ("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles ()
    {
		BuildPipeline.BuildAssetBundles ("Assets/AssetBundles", BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }

	[MenuItem ("Assets/Load AssetBundles")]
	static void LoadAllAssetBundles()
	{
		foreach (string ff in System.IO.Directory.GetFiles(Application.dataPath+"/AssetBundles")) {
			Debug.Log (ff);
			if(System.IO.FileAttributes.Hidden != System.IO.File.GetAttributes (ff) && !ff.Contains("meta"))
			{
				AssetBundle asb = AssetBundle.LoadFromFile (ff);
				foreach (Object o in asb.LoadAllAssets()) {
					Debug.Log(o.name);
					System.Type t = o.GetType();
					Debug.Log(t);
				}
			}
		}
	}
}
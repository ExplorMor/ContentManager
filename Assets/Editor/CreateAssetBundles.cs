using UnityEditor;
using UnityEngine;
using System.Collections;

public class CreateAssetBundles
{
    [MenuItem ("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles ()
    {
		string platformPath="";
		if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
			platformPath = "/Android";
		else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
			platformPath = "/iOS";
		else
			Debug.Log (EditorUserBuildSettings.activeBuildTarget);
		BuildPipeline.BuildAssetBundles ("Assets/AssetBundles"+platformPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }

	[MenuItem ("Assets/Load AssetBundles")]
	static void LoadAllAssetBundles()
	{
		string platformPath="";
		if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
			platformPath = "/Android";
		else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
			platformPath = "/iOS";
		else
			Debug.Log (EditorUserBuildSettings.activeBuildTarget);
		foreach (string ff in System.IO.Directory.GetFiles(Application.dataPath+"/AssetBundles"+platformPath)) {
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
using UnityEngine;

using UnityEngine.UI;
using System.Collections;



public class ButtonURL : MonoBehaviour 
{

	
	public string hyperlink;

	private GameObject sceneManager;
	private URLLauncher urlLauncher;

	// Use this for initialization
	
	void Awake () 
	{
	
				
		sceneManager = GameObject.Find ("ARSceneManager");
		
		if (sceneManager != null) 
		{
			urlLauncher = sceneManager.GetComponent<URLLauncher> ();			

			if (urlLauncher != null) 
				Debug.Log ("ButtonURL: urlLauncher");
		}

	}
	
	

	// Update is called once per frame
	
	void Update () 
	{
	
	

	}


	//Take naked adresses and append the 'http'
	public void openLink()
	{
		urlLauncher.URLOpenButton("http://"+hyperlink);

//		#if UNITY_IOS
//			urlLauncher.URLOpenButton("http://"+hyperlink);
//		#elif UNITY_ANDROID
//			Application.OpenURL("http://"+hyperlink);
//		#endif

	}


}

using UnityEngine;

using System.Collections;



public class SendTweet : MonoBehaviour 
{

	

	private const string tweetAddress = "http://twitter.com/intent/tweet";
	private const string tweetLanguage = "en";
	private const string hashTag = " #idigbio";
	public string tweet;

	private GameObject sceneManager;
	private URLLauncher urlLauncher;

	// Use this for initialization
	
	void Awake () 
	{

		Debug.Log ("sendTweet: Awake");

		sceneManager = GameObject.Find ("ARSceneManager");

		if (sceneManager != null) 
		{
			urlLauncher = sceneManager.GetComponent<URLLauncher> ();			
			Debug.Log ("sendTweet: sceneManager");

			if (urlLauncher != null) 
				Debug.Log ("sendTweet: urlLauncher");
		}
				
	}
	
	
	
	// Update is called once per frame
	
	void Update () 
	{

	}

	public void sendTweet()
	{		
		Debug.Log ("sendTweet");
		string tweetURL = tweetAddress +
			"?text=" + WWW.EscapeURL ("iDigBio@iDigBio\n" + tweet + hashTag) +
			"&amp;lang=" + WWW.EscapeURL (tweetLanguage);

		urlLauncher.URLOpenButton(tweetURL);

//		#if UNITY_IOS
//			urlLauncher.URLOpenButton(tweetURL);
//		#elif UNITY_ANDROID
//			Application.OpenURL(tweetURL);
//		#endif

	}

}

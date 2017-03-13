      using UnityEngine;
using System.Collections;

public class URLLauncher : MonoBehaviour {
	public GameObject arCamera;
	public GameObject urlViewerObject;
	public openURL openURLScript;


	private IEnumerator ResetToLandscapeSmoothly() 
	{
		Screen.autorotateToPortrait = false;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortraitUpsideDown = false;
		
		if (Screen.orientation == ScreenOrientation.Portrait) {
			// We need to trigger a screen orientation "reset", 
			// so, first we set it temporarily to landscape
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			
			// we wait for end of frame
			yield return new WaitForEndOfFrame ();

		} else {
			// the screen orientation was already != Portrait
			// so we can reset to Portrait immediately
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
	}

	public void URLDoneButton()
	{
		#if UNITY_IOS
		IOSNativeUtility.ShowPreloader(0f);
		#elif UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Small);
		
		Handheld.StartActivityIndicator();
		#endif

		if (urlViewerObject.activeSelf)
		{
			urlViewerObject.SetActive(false);
		}

		if (!arCamera.activeSelf)
		{
			arCamera.SetActive(true);
		}
		Invoke ("DisableActivityLoader", 1.5f);
	}

	public void URLOpenButton(string URL)
	{		

		if (arCamera.activeSelf)
		{
			arCamera.SetActive(false);
		}

		StartCoroutine ( ResetToLandscapeSmoothly() );

		if (!urlViewerObject.activeSelf)
		{
			urlViewerObject.SetActive(true);
			//openURLScript.openURLView (URL);
		}
	}

	void DisableActivityLoader()
	{
		#if UNITY_IOS
		IOSNativeUtility.HidePreloader();
		#elif UNITY_ANDROID
		Handheld.StopActivityIndicator();
		#endif
	}

}

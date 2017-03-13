using UnityEngine;
using System.Collections.Generic;

public class openURL : MonoBehaviour {

	//Just let it compile on platforms beside of iOS and Android
	//If you are just targeting for iOS and Android, you can ignore this
	#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8

	public string homeURL = "http://www.libraries-of-life.org/";

	// use pixels, automatically converts to DPI
	public Rect locationAndSize = new Rect(10,50,460,260);

	// you probabably don't want this unless you want to0 create your own UI with UIKit. Unity will be completely covered.
	private bool fullScreen = false; 

	public bool showNavigationButtons = false;

	//1. First of all, we need a reference to hold an instance of UniWebView
	private UniWebView _webView;
	private string _errorMessage;

	void Awake()
	{
		homeURL = homeURL; //WebManagerScript.webUrl;
	}

	void OnEnable()
	{
		loadUrl ();
	}

	public void unloadUrlView()
	{
		UniWebView webView = GetComponent<UniWebView> ();
		if (webView != null) {
			webView.Hide();
			Destroy(webView);
			webView.OnReceivedMessage -= OnReceivedMessage;
			webView.OnLoadComplete -= OnLoadComplete;
			webView.OnWebViewShouldClose -= OnWebViewShouldClose;
			//			webView.OnEvalJavaScriptFinished -= OnEvalJavaScriptFinished;
			webView.InsetsForScreenOreitation -= InsetsForScreenOreitation;
			_webView = null;
		}
	}

	private void loadUrl() {
		//2. You can add a UniWebView either in Unity Editor or by code.
		//Here we check if there is already a UniWebView component. If not, add one.
		_webView = GetComponent<UniWebView> ();
		if (_webView == null) {
			_webView = gameObject.AddComponent<UniWebView> ();
			_webView.OnReceivedMessage += OnReceivedMessage;
			_webView.OnLoadComplete += OnLoadComplete;
			_webView.OnWebViewShouldClose += OnWebViewShouldClose;
			//				_webView.OnEvalJavaScriptFinished += OnEvalJavaScriptFinished;

			_webView.InsetsForScreenOreitation += InsetsForScreenOreitation;
		}


		// Now, set the url you want to load. From Web
		_webView.url = homeURL;


		//		//From Local folder
		//		#if UNITY_EDITOR
		//		_webView.url = Application.streamingAssetsPath + "/Secimencard.pdf";
		//		#elif UNITY_IOS
		//		_webView.url = Application.streamingAssetsPath + "/Secimencard.pdf";
		//		#elif UNITY_ANDROID
		//		_webView.url = "file:///android_asset/Secimencard.pdf";
		//		#elif UNITY_WP8
		//		_webView.url = "Data/StreamingAssets/Secimencard.pdf";
		//		#endif

		// You can set the spinner visibility and text of the webview.
		// This line can change the text of spinner to "Wait..." (default is  "Loading...")
		//_webView.SetSpinnerLabelText("Wait...");
		// This line will tell UniWebView to not show the spinner as well as the text when loading.
		//_webView.SetShowSpinnerWhenLoading(false);

		//4.Now, you can load the webview and waiting for OnLoadComplete event now.
		_webView.Load ();

		_errorMessage = null;

		//If you want the webview show immediately, instead of the OnLoadComplete event, call Show()
		//A blank webview will appear first, then load the web page content in it
		_webView.Show ();

	}

	private void goBack() 
	{
		_webView.GoBack();
	}



	//5. When the webView complete loading the url sucessfully, you can show it.
	//   You can also set the autoShowWhenLoadComplete of UniWebView to show it automatically when it loads finished.
	void OnLoadComplete(UniWebView webView, bool success, string errorMessage) {
		if (success) {
			webView.Show();
		} else {
			Debug.Log("Something wrong in webview loading: " + errorMessage);
			_errorMessage = errorMessage;
		}
	}

	//6. The webview can talk to Unity by a url with scheme of "uniwebview". See the webpage for more
	//   Every time a url with this scheme clicked, OnReceivedMessage of webview event get raised.
	void OnReceivedMessage(UniWebView webView, UniWebViewMessage message) {
		if (string.Equals(message.path, "close")) {
			//8. When you done your work with the webview, 
			//you can hide it, destory it and do some clean work.
			webView.Hide();
			Destroy(webView);
			webView.OnReceivedMessage -= OnReceivedMessage;
			webView.OnLoadComplete -= OnLoadComplete;
			webView.OnWebViewShouldClose -= OnWebViewShouldClose;
			//			webView.OnEvalJavaScriptFinished -= OnEvalJavaScriptFinished;
			webView.InsetsForScreenOreitation -= InsetsForScreenOreitation;
			_webView = null;
		}
	}

	//10. If the user close the webview by tap back button (Android) or toolbar Done button (iOS), 
	//    we should set your reference to null to release it. 
	//    Then we can return true here to tell the webview to dismiss.
	bool OnWebViewShouldClose(UniWebView webView) {
		if (webView == _webView) {
			_webView = null;
			return true;
		}
		return false;
	}

	// This method will be called when the screen orientation changed. Here we returned UniWebViewEdgeInsets(5,5,bottomInset,5)
	// for both situation. Although they seem to be the same, screenHeight was changed, leading a difference between the result.
	// eg. on iPhone 5, bottomInset is 284 (568 * 0.5) in portrait mode while it is 160 (320 * 0.5) in landscape.
	UniWebViewEdgeInsets InsetsForScreenOreitation(UniWebView webView, UniWebViewOrientation orientation) {
		int bottomInset = 0; //(int)(UniWebViewHelper.screenHeight * 0.5f); //421

		if (orientation == UniWebViewOrientation.Portrait) {
			return new UniWebViewEdgeInsets(5,5,bottomInset,5);
		} else {
			return new UniWebViewEdgeInsets(60,5,bottomInset,5);
		}
	}
	#else //End of #if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
	void Start() {
	Debug.LogWarning("UniWebView only works on iOS/Android/WP8. Please switch to these platforms in Build Settings.");
	}
	#endif

}

//#define SA_DEBUG_MODE
using UnityEngine;
using System.Collections;
#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
using System.Runtime.InteropServices;
#endif



public class IOSNativeUtility {
	
	
	#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
	
	[DllImport ("__Internal")]
	private static extern void _ISN_ShowPreloader(float currentProgress);
	
	[DllImport ("__Internal")]
	private static extern void _ISN_HidePreloader();
	

	#endif

	public static void ShowPreloader(float currentProgress) {
		#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
		_ISN_ShowPreloader( currentProgress);
		#endif
	}
	
	public static void HidePreloader() {
		#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
		_ISN_HidePreloader();
		#endif
	}
	
	
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.IO;
using UnityEngine.Serialization;

public class Share : MonoBehaviour {

	[SerializeField] private string shareSubject, shareMessage;
	[SerializeField] private bool screenShot;
	
	private string _mScreenshotName;

	private void Awake() {
		
		_mScreenshotName = "ScreenShot.png";
	}


	public void ShareToSocial () {
		
		StartCoroutine (ShareScreenshotInAndroid ());
	}

	
	private IEnumerator ShareScreenshotInAndroid () {
		
		yield return new WaitForEndOfFrame ();

		if (Application.isEditor) yield break;
		var intentClass = new AndroidJavaClass ("android.content.Intent");
		var intentObject = new AndroidJavaObject ("android.content.Intent");
		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));

		if (screenShot) {
				
			var screenShotPath = Application.persistentDataPath + "/" + _mScreenshotName;
			ScreenCapture.CaptureScreenshot(_mScreenshotName, 1);
			yield return new WaitForSeconds(0.5f);
				
			var uriClass = new AndroidJavaClass("android.net.Uri");
			var uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + screenShotPath);

			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			intentObject.Call<AndroidJavaObject>("setType", "image/png");
		}
		else
			intentObject.Call<AndroidJavaObject>("setType", "text/plain");

		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), shareSubject);
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), shareMessage);

		var unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		var currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		var chooser = intentClass.CallStatic<AndroidJavaObject> ("createChooser", intentObject, "Share your high score");
		currentActivity.Call ("startActivity", chooser);
	}
	
}

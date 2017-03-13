using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyController : MonoBehaviour {

	public GameObject HabitatView;
	public GameObject LifecycleView;
	public GameObject BackgroundView;

	private Canvas CardUI;

	void Awake()
	{
		CardUI = this.GetComponent<Canvas> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ToggleHabitatView()
	{
		HabitatView.SetActive (!HabitatView.activeSelf);
	}

	public void ToggleLifecycleView()
	{
		BackgroundView.SetActive (LifecycleView.activeSelf);
		LifecycleView.SetActive (!LifecycleView.activeSelf);

	}

	public void ToggleExtendedTracking()
	{
		CardUI.enabled = !CardUI.enabled;

		if (CardUI.enabled) {
		} else { //The trackable should not respond during extended tracking.

		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimate : MonoBehaviour {

	public Animator animatorController;
	private SphereCollider sCollider;

	void Start () 
	{
		sCollider = this.GetComponent<SphereCollider>();

	}



	// Update is called once per frame

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (sCollider.Raycast(ray, out hit, 10000.0F))
				AnimationPlay();
		}
	}


	public void AnimationPlay()
	{	
		Debug.Log ("hit");
		if (animatorController != null) 
		{
			if (animatorController.GetCurrentAnimatorStateInfo (0).IsName ("Done"))
				animatorController.SetTrigger ("Activate");
		}
	}
}

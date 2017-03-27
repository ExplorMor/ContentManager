using UnityEngine;
using System.Collections;


public class ClickFlip : MonoBehaviour 
{
	// Use this for initialization
	private SphereCollider sCollider;
	void Start () 
	{
		Debug.Log ("1");
		sCollider = this.GetComponentInChildren<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (sCollider != null)
			{
				if (sCollider.Raycast(ray, out hit, 10000.0F))
					Flip ();
			}

		}
		
		if (Input.GetKey (KeyCode.Space)) 
		{
			Debug.Log ("4");
			Flip ();
		}
			
	}	
	
	public void Flip()
	{
		Debug.Log ("5");
		transform.Rotate (Vector3.right, 180f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFlipper : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void Flip()
	{
		this.transform.Find ("Miami6").rotation = Quaternion.Euler (new Vector3 (90, 0, 0));
	}
}

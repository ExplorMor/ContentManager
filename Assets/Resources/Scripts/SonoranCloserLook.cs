using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonoranCloserLook : MonoBehaviour 
{
    public GameObject CloserLookImage;
    public GameObject CardModel;

	// Use this for initialization
	void Start () 
    {
		CloserLookImage.SetActive (false);
		CardModel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void ToggleCloserLook()
    {
        if (CloserLookImage.activeSelf)
        {
            CloserLookImage.SetActive(false);
            CardModel.SetActive(true);
        }
        else
        {
            CloserLookImage.SetActive(true);
            CardModel.SetActive(false);
        }
    }
}

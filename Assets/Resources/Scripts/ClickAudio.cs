using UnityEngine;
using System.Collections;


public class ClickAudio : MonoBehaviour 
{

	
// Use this for initialization
	
	public AudioSource clickAudio;
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
                		AudioPlay();
		}
	}


	public void AudioPlay()
	{	
		if (clickAudio != null && clickAudio.clip != null) 
		{
			if(!clickAudio.isPlaying)
				clickAudio.Play();
		}
	}

}

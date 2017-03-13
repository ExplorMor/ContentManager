using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class NarrationAudio : MonoBehaviour 
{
	public AudioSource narration;
	public GameObject TextBox;
	public string NarrationText { get { return TextBox.GetComponent<Text>().text; } 
                            set { TextBox.GetComponent<Text>().text = value; } }

	// Use this for initialization
	
	void Start () 
	{
	

		narration = this.GetComponent<AudioSource>();
		if(narration.isPlaying)
			narration.Stop();
	}
	
	

	// Update is called once per frame
	
	void Update () 
	{
	
	
		if(TextBox != null)
		{
			if(narration.isPlaying)
			{
				TextBox.SetActive(true);
			}
			else
			{
				TextBox.SetActive(false);
				
			}
		}
	}

	public void PlayAudio()
	{
		if(!narration.isPlaying)
		{
			narration.Play();
		}
		else
			narration.Stop();
	}
	


}

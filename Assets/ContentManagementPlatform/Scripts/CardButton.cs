using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class CardButton : MonoBehaviour 
{
	[SerializeField] public Sprite Image{ get { return this.GetComponentInChildren<Image> ().sprite; }
											set { this.GetComponentInChildren<Image> ().sprite = value; } }
	[SerializeField] public float Aspect { get { return this.GetComponentInChildren<AspectRatioFitter> ().aspectRatio; } 
									set { this.GetComponentInChildren<AspectRatioFitter> ().aspectRatio = value; } }
	[SerializeField] public string Link { get { return this.GetComponentInChildren<ButtonURL> ().hyperlink; }
											set { this.GetComponentInChildren<ButtonURL> ().hyperlink = value; } }

											//We should consider trying to convince Anne that buttons on the right-side
											//should only control web links. The narration panel should have its own button
											//to the left-hand side; de-coupling that behaviour across the breadth of the card
											//is confusing. 
											public enum ButtonBehaviour 
											{
												Link = 0, 
												Audio = 1
											}
	void Awake()
	{
		Image = this.GetComponentInChildren<Image>().sprite;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void DoAspect()
	{
		int height = this.GetComponentInChildren<Image>().mainTexture.height;
		int width = this.GetComponentInChildren<Image>().mainTexture.width;
		
		GetComponentInChildren<AspectRatioFitter> ().aspectRatio = (float)width / height;
	}
}

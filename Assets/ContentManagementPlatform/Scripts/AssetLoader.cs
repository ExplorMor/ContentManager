using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour {

    private byte[] asset_memory;
    private string path;
    private int size; 

    private float requestSpeed = 0.1f;

    AssetBundleCreateRequest abcr;
    AssetBundleRequest abr;

	// Use this for initialization
	void Awake () 
    {
        
	}

    void Start()
    {

    }

    public void AssetLoad(string fp, int s, byte[] mem)
    {
        if (System.IO.File.Exists(fp))
        {
            path = fp;
            size = s;
            asset_memory = mem;
            Debug.Log("File found at : " + path);
            Debug.Log("Expected size: " + size);
            StartCoroutine("CheckFile");
        }
        else
            Debug.Log("File not found at : " + path);
    }
	
	// Update is called once per frame
	void Update()
    {
        
	}

    IEnumerator CheckAssets()
    {
        Debug.Log("Check assets present");
        StopCoroutine("CheckFile");
        while (true)
        {
            yield return new WaitForSeconds(requestSpeed);
            if (abcr.isDone)
            {
                Debug.Log("Assets loaded");
                if(abr == null)
                    abr = abcr.assetBundle.LoadAllAssetsAsync();
                if (abr.isDone)
                {
                    foreach (Object o in abr.allAssets)
                    {
                        Debug.Log(o.name);
                        Debug.Log(o.GetType());
                    }
                    StopCoroutine("CheckAssets");
                }
            }
        }
    }

    IEnumerator CheckFile()
    {
        while (true)
        {
            yield return new WaitForSeconds(requestSpeed);

            int fSize = (int)new System.IO.FileInfo(path).Length;
            Debug.Log("Checking against current file size: " + fSize);

            if (fSize == size)
            {
                Debug.Log("File size checks out");

                AssetBundle abcf = AssetBundle.LoadFromFile(path);
                if (abcf != null)
                {
                    foreach (Object o in abcf.LoadAllAssets())
                    {
                        Debug.Log(o.name);
                        System.Type t = o.GetType();
                        Debug.Log(t);
                        if (t == typeof(GameObject))
                        {
                            if ((o as GameObject).GetComponentInChildren<SendTweet>() != null)
                            {
                                GameObject cardObj = GameObject.Instantiate(o) as GameObject;
                                cardObj.transform.parent = FindObjectOfType<Camera>().transform;
                                cardObj.transform.position = new Vector3(0, 0, 15);

                                Debug.Log(cardObj.GetComponentInChildren<SendTweet>().tweet);
                                cardObj.GetComponentInChildren<SendTweet>().sendTweet();
                            }
                        }
                        Debug.Break();
                    }
                }

                StopCoroutine("CheckFile");
                //abcr = AssetBundle.LoadFromFileAsync(path);
                //StartCoroutine("CheckAssets");
            }
        }
    }
}

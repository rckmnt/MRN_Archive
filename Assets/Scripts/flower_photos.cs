using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Crayon;

public class flower_photos : MonoBehaviour {
	
	public int numImgs = 6;
	public List<GameObject> objects;
	public GameObject selector; //selected in the editor


	private Object[] photos;
	private GameObject go;

	void Start()
	{
		photos = Resources.LoadAll("0002");

		foreach (var photo in photos)
		{
			Debug.Log(photo.name);
		}

		go = GameObject.CreatePrimitive(PrimitiveType.Cube);
	}

//	void OnGUI()
//	{
//		if (GUI.Button(new Rect(10, 70, 150, 30), "Change texture"))
//		{
//			// change texture on cube
//			Texture2D texture = (Texture2D)photos[Random.Range(0, photos.Length)];
//			go.GetComponent<Renderer>().material.mainTexture = texture;
//		}
//	}


//
//		private Transform newpos;
//
//		foreach (GameObject item in objects)
//		{
//			Debug.Log (item.transform);
////			item.transform.position = new Vector3 (newpos.x, newpos.y, newpos.z)
//		}

//		selectorList = new GameObject[numImgs];
//		for (int i = 0; i < numImgs; i++)
//		{
//			GameObject go = Instantiate(selector, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
//			go.transform.localScale = Vector3.one;
//			selectorList[i] = go;
//		}


	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		// this object was clicked - do something
		// Destroy (this.gameObject);
		this.gameObject.SetColor("#FF0000", 0.8f);
	}
		
	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
	}


}

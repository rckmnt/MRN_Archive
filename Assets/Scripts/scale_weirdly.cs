using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_weirdly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


	void OnMouseDown(){
		// this object was clicked - do something
		// Destroy (this.gameObject);
		// this.gameObject.SetColor("#FF0000", 0.8f);
	
		transform.localScale = new Vector3( Random.Range(0.1f, 5.0f), Random.Range(0.1f, 5.0f) , Random.Range(0.1f, 5.0f));	
	
	}

	// Update is called once per frame
	void Update () {
		
	}
}

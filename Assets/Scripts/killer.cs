using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killer : MonoBehaviour {

	// If you create multiple objects it 

	void Awake () {
		if (FindObjectsOfType (GetType()).Length > 1) {
			Destroy (transform.gameObject);
		}
	}

}

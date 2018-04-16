using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlowerOnClick : MonoBehaviour {


    public FlowerController flower;
    
	// Update On Click
	void OnMouseDown() {

        Debug.Log("Sphere Clicked!");
        flower.IsFlowerExpanded = !flower.IsFlowerExpanded;
        	
	}
}

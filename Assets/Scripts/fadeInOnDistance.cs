using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fadeInOnDistance : MonoBehaviour {

//	Transparency and Scale
	public GameObject trolley;
	public GameObject mySprite;
	private float distance = 20f;
	private SpriteRenderer m_SpriteRenderer;
	Color tmp;
	Color color;
	public float small = 4f;
	public float big = 10f;
	private float scaleFactor = 1.0f;

//	LookAt other Object
	private Quaternion _lookRotation;
	private Vector3 _direction;


//	Color color = new Color(0.2F, 0.3F, 0.4F, 0.5F);

	// Use this for initialization
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		tmp = mySprite.GetComponent<SpriteRenderer>().color;
		color = m_SpriteRenderer.material.color;
	}

	public static float Remap (float from, float fromMin, float fromMax, float toMin,  float toMax){
		var fromAbs  =  from - fromMin;
		var fromMaxAbs = fromMax - fromMin;      
		var normal = fromAbs / fromMaxAbs;
		var toMaxAbs = toMax - toMin;
		var toAbs = toMaxAbs * normal;
		var to = toAbs + toMin;
		return to;
	}


	// Update is called once per frame
	void Update () {
		
		distance = Vector3.Distance(this.transform.position, trolley.transform.position);
		tmp.a = 1.0f;
		Debug.Log(distance);


		if (distance < 12) {
//			mySprite.SetActive (true);
			// Scale and Transparency
			tmp.a = Remap(distance, small, big, 1.0f, 0.0f);
			scaleFactor = Remap(distance, small, big, 2.0f, 1.0f);
			mySprite.GetComponent<SpriteRenderer>().color = tmp;
			mySprite.transform.localScale = new Vector3(scaleFactor,scaleFactor,scaleFactor);

			// LookAt from Object to Trolley

//			//find the vector pointing from our position to the target
//			_direction = (mySprite.transform.position - trolley.transform.position).normalized;
//			_lookRotation = Quaternion.LookRotation(_direction, Vector3.up);
//			//rotate us over time according to speed until we are in the required rotation
//			mySprite.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 1f ); //Time.deltaTime * RotationSpeed


		} else {
//		 	mySprite.SetActive (false);
			tmp.a = 0.0f;
			mySprite.GetComponent<SpriteRenderer>().color = tmp;
			mySprite.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
		}

	}
}

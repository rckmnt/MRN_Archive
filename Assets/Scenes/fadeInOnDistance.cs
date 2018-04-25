using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fadeInOnDistance : MonoBehaviour {




//	public Sprite mySprite;
	public GameObject trolley;
	public GameObject mySprite;
	private float distance = 20f;
	private float alpha;
	private SpriteRenderer m_SpriteRenderer;
	Color tmp;
	Color color;
	public float small = 4f;
	public float big = 10f;

//	Color color = new Color(0.2F, 0.3F, 0.4F, 0.5F);

	// Use this for initialization
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		tmp = mySprite.GetComponent<SpriteRenderer>().color;
		color = m_SpriteRenderer.material.color;
	}

	public static float Remap (float from, float fromMin, float fromMax, float toMin,  float toMax)
	{
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
			tmp.a = Remap(distance, small, big, 1.0f, 0.0f);
			mySprite.GetComponent<SpriteRenderer>().color = tmp;

		} else {
//		 	mySprite.SetActive (false);
			tmp.a = 0.0f;
			mySprite.GetComponent<SpriteRenderer>().color = tmp;
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crayon;

public class FlowerController : MonoBehaviour {

    public Sprite[] spritesForPetals;

    public GameObject petalPrefab;
    private GameObject[] petals;

    private Vector3[] petalPositionsOpen;
    private Vector3[] petalPositionsClosed;
    private Vector3 petalScaleOpen;
    private Vector3 petalScaleClosed;

    public bool isThisFlowerOpenOnStart;

    private float initialAngleOriginInDeg = 10f;

    private bool isFlowerExpanded;
    public bool IsFlowerExpanded
    {
        get { return isFlowerExpanded; }
        set
        {
            isFlowerExpanded = value;
            ExpandPetals(isFlowerExpanded);
        }
    }

    public void Awake()
    {
        // Instantiate our petals
        petals = new GameObject[spritesForPetals.Length];
        petalPositionsOpen = new Vector3[spritesForPetals.Length];
        petalPositionsClosed = new Vector3[spritesForPetals.Length];
        for (int i = 0; i < petals.Length; i++)
        {
            petals[i] = Instantiate(petalPrefab, transform);
            petals[i].GetComponentInChildren<SpriteRenderer>().sprite = spritesForPetals[i];
        }

        // Initialize the cached transform values
        StoreExtremePetalPositions();

        // Initial Petal Tranforms
        InitializePetalPositions(isThisFlowerOpenOnStart);
        InitializePetalsScale(isThisFlowerOpenOnStart);


		// Set IsFlowerExpanded to isThisFlowerOpenOnStart
		isFlowerExpanded = isThisFlowerOpenOnStart;


    }


    private void StoreExtremePetalPositions()
    {
        float petalMaxRadius = FlowersManager.Instance.petalMaxRadius;
        for (int i = 0; i < petals.Length; i++)
        {
            float petalAngleInDeg = initialAngleOriginInDeg + 360f / petals.Length * i;
            petalPositionsOpen[i] = AngleToVec(petalAngleInDeg) * petalMaxRadius;
			// For some reason can't be 0, because it gets multiplied? 
            petalPositionsClosed[i] = petalPositionsOpen[i] * -1;
        }

        petalScaleOpen = new Vector3(FlowersManager.Instance.petalMaxScale, FlowersManager.Instance.petalMaxScale, 1f);
		petalScaleClosed = new Vector3(0.05f, 0.05f, 1f);
        //float invMaxPetalScale = 1f / FlowersManager.Instance.petalMaxScale;
        //petalScaleClosed = new Vector3(invMaxPetalScale, invMaxPetalScale, 1f);
    }


    private void InitializePetalPositions(bool isOpen)
    {
        for (int i = 0; i < petals.Length; i++)
        {
            petals[i].transform.localPosition = (isOpen) ? petalPositionsOpen[i] : petalPositionsClosed[i];
        }
    }

    private void InitializePetalsScale(bool isOpen)
    {
        for (int i = 0; i < petals.Length; i++)
        {
            petals[i].transform.GetChild(0).localScale = (isOpen) ? petalScaleOpen : petalScaleClosed;
        }

    }
    

    private Vector3 AngleToVec(float angleInDeg)
    {
        return new Vector3(Mathf.Cos(angleInDeg * Mathf.Deg2Rad), Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0);

    }

    private void ExpandPetals(bool isExpanding)
    {
        for (int i = 0; i < petals.Length; i++)
        {
            if (isExpanding)
            {
				petals[i].SetRelativePosition(petalPositionsOpen[i], 0.2f, Easing.Custom, "0.05,0.78,0.65,0.99");
//                petals[i].SetRelativePosition(petalPositionsOpen[i], 0.2f, Easing.Linear);
                petals[i].transform.GetChild(0).gameObject.SetScale(petalScaleOpen, 0.2f);
            }
            else
            {
                petals[i].SetRelativePosition(petalPositionsClosed[i], 1.2f, Easing.Custom, "0.05,0.78,0.65,0.99");
                petals[i].transform.GetChild(0).gameObject.SetScale(petalScaleClosed, 1.2f);
            }

        }
    }






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersManager : Singleton<FlowersManager>
{

    private float maxSpriteHeight = 1.5f;
    public float MaxSpriteHeight
    {
        get { return maxSpriteHeight; }
    }
    public float petalMaxRadius;
    public float petalMaxScale;

}

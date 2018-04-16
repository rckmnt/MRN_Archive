using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteTextureScaler : MonoBehaviour
{
    private SpriteRenderer renderer;
    private float spriteAspectRatio;

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();

        spriteAspectRatio = renderer.size.x / renderer.size.y;
        ChangeSpriteDimensions();
    }

    private void ChangeSpriteDimensions()
    {
        float spriteInitialHeight = FlowersManager.Instance.MaxSpriteHeight;
        transform.localScale = new Vector3(spriteAspectRatio * spriteInitialHeight , spriteInitialHeight, 1f);
    }
}

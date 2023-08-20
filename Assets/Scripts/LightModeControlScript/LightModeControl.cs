using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModeControl : MonoBehaviour
{
    protected bool _whiteLight;
    public Sprite blackSprite;
    public Sprite whiteSprite;
    void Start()
    {
        SelectBackgroundSprite();
    }

    void SelectBackgroundSprite()
    {
        if (_whiteLight)
        {
            transform.GetComponent<SpriteRenderer>().sprite = whiteSprite;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().sprite = blackSprite;
        }
    }
}

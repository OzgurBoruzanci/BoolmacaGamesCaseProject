using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominaAreaLightControl : MonoBehaviour
{
    protected bool _whiteLight;
    public Sprite blackSprite;
    public Sprite whiteSprite;
    void Start()
    {
        SelectBackgroundSprite();
    }

    protected void SelectBackgroundSprite()
    {
        if (_whiteLight)
        {
            transform.GetComponent<SpriteRenderer>().sprite = blackSprite;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().sprite = whiteSprite;
        }
    }
}

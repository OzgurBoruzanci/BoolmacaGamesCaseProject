using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class LightModeControl : MonoBehaviour
{
   
    protected bool _whiteLight;
    public Sprite blackSprite;
    public Sprite whiteSprite;

    private void OnEnable()
    {
        EventManager.LightControl += LightControl;
    }
    private void OnDisable()
    {
        EventManager.LightControl -= LightControl;
    }

    void Start()
    {
        SelectBackgroundSprite();
    }

    void LightControl(bool lightCntrl)
    {
        _whiteLight=lightCntrl;
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

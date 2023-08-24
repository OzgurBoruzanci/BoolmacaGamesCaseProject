using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
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
    private void OnEnable()
    {
        EventManager.LightControl += LightControl;
    }
    private void OnDisable()
    {
        EventManager.LightControl -= LightControl;
    }
    void LightControl(bool lightCntrl)
    {
        _whiteLight = lightCntrl;
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

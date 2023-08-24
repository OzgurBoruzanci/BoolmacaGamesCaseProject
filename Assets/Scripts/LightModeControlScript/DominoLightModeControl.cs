using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoLightModeControl : MonoBehaviour
{
    public GameManagerSC gameManagerSC;
    bool _domino;
    bool _whiteBackground;
    public List<Sprite> purpleDominoSprites;
    public List<Sprite> whiteColorSprites;
    public List<Sprite> whiteDominoSprites;
    public List<Sprite> purpleColorSprites;
    void Start()
    {
        SelectDominoSprite();
    }

    private void OnEnable()
    {
        EventManager.LightControl += LightControl;
        EventManager.DominoSprite += DominoSprite;
    }
    private void OnDisable()
    {
        EventManager.LightControl -= LightControl;
        EventManager.DominoSprite -= DominoSprite;
    }
    void DominoSprite(bool dominoS)
    {
        _domino = dominoS;
        SelectDominoSprite();
    }
    void LightControl(bool lightCntrl)
    {
        _whiteBackground = lightCntrl;
        SelectDominoSprite();
    }
    void SelectDominoSprite()
    {
        _domino = gameManagerSC.dominoSprite;
        _whiteBackground = gameManagerSC.lightControl;
        if (_domino && _whiteBackground)
        {
            transform.GetComponent<SpriteRenderer>().sprite = purpleDominoSprites[Random.Range(0, 5)];
        }
        else if (!_domino && _whiteBackground)
        {
            transform.GetComponent<SpriteRenderer>().sprite = purpleColorSprites[Random.Range(0, 5)];
        }
        else if (!_domino && !_whiteBackground)
        {
            transform.GetComponent<SpriteRenderer>().sprite = whiteColorSprites[Random.Range(0, 5)];
        }
        else if (_domino && !_whiteBackground)
        {
            transform.GetComponent<SpriteRenderer>().sprite = whiteDominoSprites[Random.Range(0, 5)];
        }
    }
}

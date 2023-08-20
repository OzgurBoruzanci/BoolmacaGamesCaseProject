using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoLightModeControl : MonoBehaviour
{
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


    void SelectDominoSprite()
    {
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

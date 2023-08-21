using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCellManager : LightModeControl
{
    [HideInInspector] public bool filled;

    private void OnTriggerEnter2D(Collider2D collision)
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
    private void OnTriggerExit2D(Collider2D collision)
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

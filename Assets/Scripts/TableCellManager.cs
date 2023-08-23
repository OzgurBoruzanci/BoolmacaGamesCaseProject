using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCellManager : LightModeControl
{
    [HideInInspector] public bool filled;
    public ChildDominoBase OnChildDominoBase;/* { get; set; }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TableCellHitControl();
        StartCoroutine(HitDomino());
    }
    
    void TableCellHitControl()
    {
        if (OnChildDominoBase==null)
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

    IEnumerator HitDomino()
    {
        yield return new WaitForSeconds(0.5f);
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

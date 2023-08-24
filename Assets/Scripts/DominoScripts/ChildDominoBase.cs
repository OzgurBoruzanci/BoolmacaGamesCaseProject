using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDominoBase : MakeARayCastHit
{
    GameObject collObject;
    bool setleDomino = false;
    bool hitTheDomino = false;
    [HideInInspector] public bool isOnPointerUp=false;
    [HideInInspector] public List<bool> equalSprites;

    private void OnEnable()
    {
        EventManager.SettledDownDomino += SettledDownDomino;
        EventManager.DidNotSettle += DidNotSettle;
    }
    private void OnDisable()
    {
        EventManager.SettledDownDomino -= SettledDownDomino;
        EventManager.DidNotSettle -= DidNotSettle;
    }

    void SettledDownDomino()
    {
        setleDomino = true;
    }
    void DidNotSettle()
    {
        setleDomino = false;
        equalSprites.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MakeARayCastHit>() && !setleDomino)
        {
            collObject= collision.gameObject;
            hitTheDomino = true;
            if (transform.GetComponent<SpriteRenderer>().sprite == collision.GetComponent<SpriteRenderer>().sprite)
            {
                equalSprites.Add(true);
            }
            else
            {
                equalSprites.Add(false);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collObject==collision.gameObject)
        {
            hitTheDomino = false;

        }

    }
    public void OnHitTheDomino()
    {
        if (!hitTheDomino)
        {

            equalSprites.Add(true);
        }
    }
}

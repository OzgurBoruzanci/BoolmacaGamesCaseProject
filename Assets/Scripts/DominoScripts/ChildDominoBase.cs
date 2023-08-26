using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDominoBase : MakeARayCastHit
{
    bool didNotHitTheDominoes = false;
    [HideInInspector] public bool isOnPointerUp=false;
    [HideInInspector] public List<bool> equalSprites;

    private void OnEnable()
    {
        EventManager.DidNotSettle += DidNotSettle;
    }
    private void OnDisable()
    {
        EventManager.DidNotSettle -= DidNotSettle;
    }

    void DidNotSettle()
    {
        equalSprites.Clear();
    }

    public bool DidNotHitTheDominoes()
    {
        Collider2D hitLeft = LeftHit();
        Collider2D hitRight = RightHit();
        Collider2D hitUp = UpHit();
        Collider2D hitDown = DownHit();
        if (!hitDown && !hitLeft && !hitRight && !hitUp)
        {
            didNotHitTheDominoes= true;
        }
        return didNotHitTheDominoes;
    }


    public void CheckNextDomino()
    {
        Collider2D hitLeft = LeftHit();
        Collider2D hitRight = RightHit();
        Collider2D hitUp = UpHit();
        Collider2D hitDown = DownHit();
        if (hitLeft && transform.GetComponent<SpriteRenderer>().sprite == hitLeft.transform.GetComponent<SpriteRenderer>().sprite)
        {
            equalSprites.Add(true);
        }

        if (hitRight && transform.GetComponent<SpriteRenderer>().sprite == hitRight.transform.GetComponent<SpriteRenderer>().sprite)
        {
            equalSprites.Add(true);
        }
        if (hitUp && transform.GetComponent<SpriteRenderer>().sprite == hitUp.transform.GetComponent<SpriteRenderer>().sprite)
        {
            equalSprites.Add(true);
        }
        if (hitDown && transform.GetComponent<SpriteRenderer>().sprite == hitDown.transform.GetComponent<SpriteRenderer>().sprite)
        {
            equalSprites.Add(true);
        }
        
    }

}

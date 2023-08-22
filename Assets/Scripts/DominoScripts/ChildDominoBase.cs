using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDominoBase : MakeARayCastHit
{
    [HideInInspector] bool setleDomino = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MakeARayCastHit>())
        {
            if (transform.GetComponent<SpriteRenderer>().sprite == collision.GetComponent<SpriteRenderer>().sprite)
            {
                setleDomino = true;
                Debug.Log("ayný" + transform.name + " ben ve o" + collision.name);
            }
            else
            {
                Debug.Log("deðil");
            }
        }
    }
}

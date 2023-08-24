using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDominoBase : MakeARayCastHit
{
    [HideInInspector] bool setleDomino = false;
     
    private void OnEnable()
    {
        EventManager.SettledDownDomino += SettledDownDomino;
    }
    private void OnDisable()
    {
        EventManager.SettledDownDomino -= SettledDownDomino;
    }
    
    void SettledDownDomino()
    {
        CheckNextDomino();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<MakeARayCastHit>())
    //    {
    //        if (transform.GetComponent<SpriteRenderer>().sprite == collision.GetComponent<SpriteRenderer>().sprite)
    //        {
    //            setleDomino = true;
    //            //Debug.Log("ayný" + transform.name + " ben ve o" + collision.name);
    //        }
    //        else
    //        {
    //            //Debug.Log("deðil");
    //        }
    //    }
    //}
    void CheckNextDomino()
    {
        List<bool> checkNextDominos = new List<bool>();
        RaycastHit2D hitLeft = LeftHit();
        RaycastHit2D hitRight = RightHit();
        RaycastHit2D hitUp=UpHit();
        RaycastHit2D hitDown = DownHit();
        if (hitLeft && transform.GetComponent<SpriteRenderer>().sprite==hitLeft.collider.transform.GetComponent<SpriteRenderer>().sprite)
        {
            Debug.Log("hitLeft " + hitLeft.transform.name);
            checkNextDominos.Add(true);
        }
        if (hitRight && transform.GetComponent<SpriteRenderer>().sprite == hitRight.collider.transform.GetComponent<SpriteRenderer>().sprite)
        {
            Debug.Log("hitRight " + hitRight.transform.name);
            checkNextDominos.Add(true);
        }
        if (hitUp && transform.GetComponent<SpriteRenderer>().sprite == hitUp.collider.transform.GetComponent<SpriteRenderer>().sprite)
        {
            Debug.Log("hitUp " + hitUp.transform.name);
            checkNextDominos.Add(true);
        }
        if (hitDown && transform.GetComponent<SpriteRenderer>().sprite == hitDown.collider.transform.GetComponent<SpriteRenderer>().sprite)
        {
            Debug.Log("hitDown " + hitDown.transform.name);
            checkNextDominos.Add(true);
        }
    }
}

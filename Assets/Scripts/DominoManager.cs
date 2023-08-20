using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DominoManager : MonoBehaviour
{
    [HideInInspector] public bool settledDown;
    float rotationZ = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (collision.gameObject.GetComponent<TableCellManager>())
            {
                transform.position = collision.transform.position;
                settledDown = true;
                EventManager.SettledDownDomino();
            }
        }
        if (collision.gameObject.GetComponent<DominoAreaManager>())
        {
            transform.localScale = Vector3.one;
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit=Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (hit.transform.GetComponent<DominoManager>() && !settledDown)
            {
                EventManager.MouseClick();
                transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, rotationZ + 90));
                
            }
        }
        
    }
    
    private void OnMouseDrag()
    {
        //    EventManager.MouseDrag();
        if (!settledDown)
        {
            transform.localScale = new Vector3(0.77f, 0.77f, 0.77f);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -0.1f;
            transform.position = mousePos;
        }
    }
}

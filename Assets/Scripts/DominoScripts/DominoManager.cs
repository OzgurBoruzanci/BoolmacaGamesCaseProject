using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class DominoManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    //[HideInInspector] public bool settledDown;
    [SerializeField] LayerMask dominoAreaMask;
    [SerializeField] LayerMask targetMask;
    
    float rotationZ = 0;
    Vector3 _ofset;
    Vector3 _firstPos;


    void Start()
    {
        _firstPos = transform.position;
    }

   
    public void OnDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        Vector3 _target = Camera.main.ScreenToWorldPoint(eventData.position);
        _target += _ofset;
        _target.z = 0;
        transform.position = _target;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, rotationZ + 90));
        //EventManager.MouseClick();
        Vector3 _target = Camera.main.ScreenToWorldPoint(eventData.position);
        _ofset = transform.position - _target;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RotateOnClick();
        ColliderHitController();
    }

    Collider2D ColliderHit(LayerMask layerMask)
    {
        var origin = transform.position;
        Collider2D col = Physics2D.OverlapPoint(transform.position, layerMask, 0, 10);
        return col;
    }

    void RotateOnClick()
    {
        Collider2D col = ColliderHit(dominoAreaMask);
        if (col != null)
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, rotationZ + 90));
            EventManager.MouseClick();
        }

    }

    void ColliderHitController()
    {
        Collider2D col = ColliderHit(targetMask);
        if (col != null)
        {
            if (col.GetComponent<TableCellManager>().OnChildDominoBase==null)
            {
               
                float _x = 0;
                float _y = 0;
                float _z = 0;
                for (int i = 0; i < transform.childCount; i++)
                {
                    _x += transform.GetChild(i).GetComponent<MakeARayCastHit>().HitPos().x;
                    _y += transform.GetChild(i).GetComponent<MakeARayCastHit>().HitPos().y;
                    _z += transform.GetChild(i).GetComponent<MakeARayCastHit>().HitPos().z;
                    transform.GetChild(i).GetComponent<MakeARayCastHit>().SetOnChildDominoBase();
                }
                transform.position = new Vector3(_x / 2, _y / 2, _z/2);
                _x = 0;
                _y = 0;
                _z = 0;
                EventManager.SettledDownDomino();
                
                col.GetComponentInParent<TableManager>().CheckCell();
            }
            else
            {
                BackFirstPos();
            }
            
        }
        else
        {
            BackFirstPos();
        }
    }
    void BackFirstPos()
    {
        transform.position = _firstPos;
        transform.localScale = Vector3.one;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakeARayCastHit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] LayerMask targetMask;
    Vector3 _firstPos;
    DominoManager _manager;

    void Start()
    {
        _firstPos = transform.parent.position;
        _manager=GetComponentInParent<DominoManager>();
    }

    private void FixedUpdate()
    {
        var hit = Hit();
        if (hit)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        _manager.OnDrag(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _manager.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RaycastHit2D hit = Hit();
        //if (hit.transform.GetComponent<DominoAreaManager>())
        //{
        //    transform.parent.localScale = Vector3.one;
        //}
        if (hit)
        {
            var target = hit.transform.position;
            target.z = 0;
            transform.parent.position = target;
        }
        else
        {
            BackFirstPos();
        }
    }
    RaycastHit2D Hit()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector3.forward, 10, targetMask);
        return hit;
    }
    void BackFirstPos()
    {
        transform.parent.position = _firstPos;
    }

}

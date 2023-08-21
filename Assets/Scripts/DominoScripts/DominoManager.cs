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
    Vector3 _ofset;

    private void Start()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 _target = Camera.main.ScreenToWorldPoint(eventData.position);
        _target += _ofset;
        _target.z = 0;
        transform.position = _target;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.77f, 0.77f, 0.77f);
        Vector3 _target = Camera.main.ScreenToWorldPoint(eventData.position);
        _ofset = transform.position - _target;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
   
}

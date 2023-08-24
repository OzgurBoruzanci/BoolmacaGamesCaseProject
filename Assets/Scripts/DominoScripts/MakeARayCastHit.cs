using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MakeARayCastHit : MonoBehaviour
{
    [SerializeField] LayerMask targetMask;
    public LayerMask childDominoMask;
    ChildDominoBase _childDominoBase;

    private void Start()
    {
        _childDominoBase= GetComponent<ChildDominoBase>();
    }

    public Vector3 HitPos()
    {
        Collider2D col = ColliderHit();
        var target = col.transform.position;
        target.z = 0.5f;
        
        return target;
    }
    public void SetOnChildDominoBase()
    {
        Collider2D col = ColliderHit();
        col.GetComponent<TableCellManager>().OnChildDominoBase = _childDominoBase;
    }
    public Collider2D ColliderHit()
    {
        var origin = transform.position;
        Collider2D col = Physics2D.OverlapPoint(transform.position, targetMask, 0, 10);
        return col;
    }

    public bool IsFullHit()
    {
        Collider2D hit = ColliderHit();
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

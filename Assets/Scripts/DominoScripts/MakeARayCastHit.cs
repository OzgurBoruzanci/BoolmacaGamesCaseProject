using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public RaycastHit2D LeftHit()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector3.left, 5, childDominoMask);
        if (hit)
        {
            Debug.Log("diðer  " + hit.transform.name);
        }
        return hit;
    }
    public RaycastHit2D RightHit()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector3.right, 3, childDominoMask);
        if (hit)
        {
            Debug.Log("diðer  " + hit.transform.name);
        }
        return hit;
    }
    public RaycastHit2D UpHit()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector3.up, 3, childDominoMask);
        if (hit)
        {
            Debug.Log("diðer  " + hit.transform.name);
        }
        return hit;
    }
    public RaycastHit2D DownHit() 
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector3.down, 3, childDominoMask);
        if (hit)
        {
            Debug.Log("diðer  " + hit.transform.name);
        }
        return hit;
    }
}

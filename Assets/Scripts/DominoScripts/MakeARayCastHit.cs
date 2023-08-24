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
    public RaycastHit2D LeftHit()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector3.left, 5, childDominoMask);
        if (hit.collider)
        {
            Debug.Log("diðer sol  " + hit.transform.name);
        }
        return hit;
    }
    public RaycastHit2D RightHit()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, transform.right, 3, childDominoMask);
        if (hit.collider)
        {
            Debug.Log("diðer sað  " + hit.transform.name);
        }
        return hit;
    }
    public RaycastHit2D UpHit()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, transform.up, 3, childDominoMask);
        if (hit.collider)
        {
            Debug.Log("diðer yukarý  " + hit.transform.name);
        }
        return hit;
    }
    public RaycastHit2D DownHit() 
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector3.down, 3, childDominoMask);
        if (hit.collider)
        {
            Debug.Log("diðer aþaðý " + hit.transform.name);
        }
        return hit;
    }
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position+transform.right*3, Color.white);
        Debug.DrawLine(transform.position, transform.position-transform.right*3, Color.green);
        Debug.DrawLine(transform.position, transform.position+transform.up*3, Color.blue);
        Debug.DrawLine(transform.position, transform.position-transform.up* 3, Color.red);
    }
}

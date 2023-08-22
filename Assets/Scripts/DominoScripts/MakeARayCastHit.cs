using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakeARayCastHit : MonoBehaviour
{
    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask setleDominoMask;
    public Vector3 HitPos()
    {
        Collider2D col = ColliderHit();
        var target = col.transform.position;
        target.z = 1;
        
        return target;
    }

    public Collider2D ColliderHit()
    {
        var origin = transform.position;
        Collider2D col = Physics2D.OverlapPoint(transform.position, targetMask, 0, 10);
        return col;
    }
    
}

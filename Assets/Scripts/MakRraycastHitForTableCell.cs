using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakRraycastHitForTableCell : MonoBehaviour
{
    [SerializeField] LayerMask targetMask;
    [HideInInspector] public List<Sprite> sprites;
    [HideInInspector] public List<bool> emptyCell;

    private void Start()
    {
        sprites = new List<Sprite>();
        emptyCell = new List<bool>();
    }
    void CheckLeftCell()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector2.left, 2.5f, targetMask);
        if (hit.transform != null)
        {
            if (hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase != null)
            {
                sprites.Add(hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase.transform.GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                emptyCell.Add(true);
            }
        }
        
    }
    void CheckRightCell()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector2.right, 2.5f, targetMask);
        if (hit.transform != null)
        {
            if (hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase != null)
            {
                sprites.Add(hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase.transform.GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                emptyCell.Add(true);
            }
        }
    }
    void CheckUpCell()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector2.up, 2.5f, targetMask);
        if (hit.transform != null)
        {
            if (hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase != null)
            {
                sprites.Add(hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase.transform.GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                emptyCell.Add(true);
            }
        }
    }
    void CheckDownCell()
    {
        RaycastHit2D hit;
        var origin = transform.position;
        hit = Physics2D.Raycast(origin, Vector2.down, 2.5f, targetMask);
        if (hit.transform != null)
        {
            
            if (hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase != null)
            {
                sprites.Add(hit.collider.transform.GetComponent<TableCellManager>().OnChildDominoBase.transform.GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                emptyCell.Add(true);
            }
        }
    }

    public void CheckNextCell()
    {
        emptyCell.Clear();
        sprites.Clear();
        CheckDownCell();
        CheckLeftCell();
        CheckRightCell();
        CheckUpCell();
    }

}

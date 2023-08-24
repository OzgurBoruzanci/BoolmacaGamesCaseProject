using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    List<GameObject> _tableCells;
    void Start()
    {
        _tableCells = new List<GameObject>();
        AddChildList();
    }

    void AddChildList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<TableCellManager>())
            {
                _tableCells.Add(transform.GetChild(i).gameObject);
            }
        }
    }


    public void CheckCell()
    {
        CheckAndDestroyRowCell();
        CheckAndDestroyColumnCell();
    }
    bool IsFullRow(int row)
    {
        for (int i = -6; i < 7f; i += 3)
        {
            for (int w = 0; w < _tableCells.Count; w++)
            {
                GameObject _cell= GetCell(w, i, row);
                if (_cell!=null && _cell.GetComponent<TableCellManager>().OnChildDominoBase==null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    bool IsFullColumn(int column)
    {
        for (int i = -6; i < 7; i += 3)
        {
            for (int w = 0; w < _tableCells.Count; w++)
            {
                GameObject _cell = GetCell(w, column, i);
                if (_cell != null && _cell.GetComponent<TableCellManager>().OnChildDominoBase == null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    GameObject GetCell(int i,int x,int y)
    {
        if (_tableCells[i].transform.localPosition.x==x)
        {
            if (_tableCells[i].transform.localPosition.y==y)
            {
                return _tableCells[i];
            }
        }
        return null;
    }

    void CheckAndDestroyRowCell()
    {
        List<int> willDestroyRowIndex = new List<int>();
        for (int i = -6; i < 7; i += 3)
        {
            if (IsFullRow(i))
            {
                willDestroyRowIndex.Add(i);
                Debug.Log(i + " " + IsFullRow(i));
            }
        }
        foreach (var rowIndex in willDestroyRowIndex)
        {
            for (int i = -6; i < 7; i += 3)
            {
                for (int j = 0; j < _tableCells.Count; j++)
                {
                    if (_tableCells[j].transform.localPosition.x == i)
                    {
                        if (_tableCells[j].transform.localPosition.y == rowIndex)
                        {
                            _tableCells[j].GetComponent<TableCellManager>().OnChildDominoBase.gameObject.SetActive(false);
                            _tableCells[j].GetComponent<TableCellManager>().OnChildDominoBase = null;
                        }
                    }
                }
            }
        }
    }
    void CheckAndDestroyColumnCell()
    {
        List<int> willDestroyColumnIndex = new List<int>();

        for (int i = -6; i < 7; i += 3)
        {
            if (IsFullColumn(i))
            {
                willDestroyColumnIndex.Add(i);
            }
        }
        foreach (var columnIndex in willDestroyColumnIndex)
        {
            for (int i = -6; i < 7; i += 3)
            {
                for (int j = 0; j < _tableCells.Count; j++)
                {
                    if (_tableCells[j].transform.localPosition.x == columnIndex)
                    {
                        if (_tableCells[j].transform.localPosition.y == i)
                        {
                            Destroy(_tableCells[j].GetComponent<TableCellManager>().OnChildDominoBase.gameObject);
                            _tableCells[j].GetComponent<TableCellManager>().OnChildDominoBase = null;
                        }
                    }
                }
            }
        }
    }
}

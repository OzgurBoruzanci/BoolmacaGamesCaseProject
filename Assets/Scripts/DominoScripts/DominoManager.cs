using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class DominoManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameManagerSC gameManagerSC;
    [SerializeField] LayerMask dominoAreaMask;
    [SerializeField] LayerMask targetMask;
    bool _clickable = true;
    float rotationZ = 0;
    Vector3 _ofset;
    Vector3 _firstPos;
    public bool isHardMode = false;

    private void OnEnable()
    {
        EventManager.HardModeOnOff += HardModeOnOff;
    }
    private void OnDisable()
    {
        EventManager.HardModeOnOff -= HardModeOnOff;
    }

    void Start()
    {
        _firstPos = transform.position;
        isHardMode = gameManagerSC.hardMod;
        EventManager.DominoSprites(CheckFirstDominoSprites(), CheckSecondDominoSprites());
        
    }
    void Update()
    {
        DestroyDomino();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_clickable)
        {
            transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
            Vector3 _target = Camera.main.ScreenToWorldPoint(eventData.position);
            _target += _ofset;
            _target.z = 0;
            transform.position = _target;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_clickable)
        {
            Vector3 _target = Camera.main.ScreenToWorldPoint(eventData.position);
            _ofset = transform.position - _target;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_clickable)
        {
            RotateOnClick();
            ColliderHitController();
        }
    }

    void HardModeOnOff(bool hardMode)
    {
        isHardMode = hardMode;
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
            if (!isHardMode)
            {
                HardModeOff(col);
            }
            else
            {
                HardModeOn(col);
            }
        }
        else
        {
            BackFirstPos();
        }
    }

    void HardModeOff(Collider2D col)
    {
        int firstChild = CheckOtherFirstChildDomino();
        int secondChild = CheckOtherSecondChildDomino();
        if (firstChild == -1 && secondChild == -1)
        {
            SettledDownDomino(col);
        }
        else if (secondChild==-1 && firstChild > 0)
        {
            SettledDownDomino(col);
        }
        else if (firstChild == -1 && secondChild > 0)
        {
            SettledDownDomino(col);
        }
        else
        {
            if (firstChild > 0 || secondChild > 0)
            {
                SettledDownDomino(col);
            }
            else
            {
                BackFirstPos();
            }
        }
    }
    void HardModeOn(Collider2D col)
    {
        int firstChild = CheckOtherFirstChildDomino();
        int secondChild = CheckOtherSecondChildDomino();
        Debug.Log(transform.name + " " + firstChild + " birinci  " + secondChild);
        if (firstChild == -1 && secondChild == -1)
        {
            SettledDownDomino(col);
        }
        else if (secondChild == -1 && firstChild > 0)
        {
            SettledDownDomino(col);
        }
        else if (firstChild == -1 && secondChild > 0)
        {
            SettledDownDomino(col);
        }
        else
        {
            if (firstChild > 0 && secondChild > 0)
            {
                SettledDownDomino(col);
            }
            else
            {
                BackFirstPos();
            }
        }
    }
    void SettledDownDomino(Collider2D col)
    {
        if (col.GetComponent<TableCellManager>().OnChildDominoBase == null &&
                   ChildColliderHitController())
        {
            PlacesDomino(col);
        }
        else
        {
            BackFirstPos();
        }
    }
    int CheckOtherFirstChildDomino()
    {
        int isTrue = 0;
        transform.GetChild(0).GetComponent<ChildDominoBase>().CheckNextDomino();
        bool didItHitTheDominoes = transform.GetChild(0).GetComponent<ChildDominoBase>().DidNotHitTheDominoes();
        if (!didItHitTheDominoes)
        {
            int childListCount = transform.GetChild(0).GetComponent<ChildDominoBase>().equalSprites.Count;
            for (int i = 0; i < childListCount; i++)
            {
                bool childListBool = transform.GetChild(0).GetComponent<ChildDominoBase>().equalSprites[i];
                if (childListBool)
                {
                    isTrue++;
                }
            }
        }
        else
        {
            isTrue--;
        }
        transform.GetChild(0).GetComponent<ChildDominoBase>().equalSprites.Clear();
        return isTrue;
    }
    int CheckOtherSecondChildDomino()
    {
        int isTrue = 0;
        transform.GetChild(1).GetComponent<ChildDominoBase>().CheckNextDomino();
        bool didItHitTheDominoes = transform.GetChild(1).GetComponent<ChildDominoBase>().DidNotHitTheDominoes();
        if (!didItHitTheDominoes)
        {
            int childListCount = transform.GetChild(1).GetComponent<ChildDominoBase>().equalSprites.Count;
            for (int i = 0; i < childListCount; i++)
            {
                bool childListBool = transform.GetChild(1).GetComponent<ChildDominoBase>().equalSprites[i];
                if (childListBool)
                {
                    isTrue++;
                }
            }
        }
        else
        {
            isTrue--;
        }
        transform.GetChild(1).GetComponent<ChildDominoBase>().equalSprites.Clear();
        return isTrue;
    }
    Sprite CheckFirstDominoSprites()
    {
        Sprite sprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        return sprite;
    }
    Sprite CheckSecondDominoSprites()
    {
        Sprite sprite = transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
        return sprite;
    }
    void PlacesDomino(Collider2D col)
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
        transform.position = new Vector3(_x / 2, _y / 2, _z / 2);
        _x = 0;
        _y = 0;
        _z = 0;

        EventManager.SettledDownDomino();
        _clickable = false;
        EventManager.CheckCell();
        EventManager.NewDomino();
    }
    bool ChildColliderHitController()
    {
        if (transform.GetChild(0).GetComponent<MakeARayCastHit>().IsFullHit() &&
            transform.GetChild(1).GetComponent<MakeARayCastHit>().IsFullHit())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void BackFirstPos()
    {
        EventManager.DidNotSettle();
        transform.position = _firstPos;
        transform.localScale = Vector3.one;
    }
    public void DestroyDomino()
    {
        if (transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}

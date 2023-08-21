using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoAreaFrameManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.MouseClick += MouseClick;
    }
    private void OnDisable()
    {
        EventManager.MouseClick -= MouseClick;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void MouseClick()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        StartCoroutine(ClickedDomino());
    }

    IEnumerator ClickedDomino()
    {
        yield return new WaitForSeconds(0.3f);
        transform.localScale = Vector3.one;
    }
}

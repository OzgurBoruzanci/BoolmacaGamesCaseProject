using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoAreaManager : DominaAreaLightControl
{
    public GameObject domino;
    float rotationZ = 0;
    private void OnEnable()
    {
        EventManager.MouseClick += MouseClick;
        EventManager.SettledDownDomino += SettledDownDomino;
    }
    private void OnDisable()
    {
        EventManager.MouseClick -= MouseClick;
        EventManager.SettledDownDomino -= SettledDownDomino;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MouseClick()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, rotationZ + 90));
    }
    void SettledDownDomino()
    {
        Instantiate(domino,transform.position,Quaternion.identity);
    }
}

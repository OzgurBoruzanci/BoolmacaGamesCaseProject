using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    void MouseClick()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, rotationZ + 90));
    }
    void SettledDownDomino()
    {
        Vector3 newDominoPos = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(domino, newDominoPos, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManagerSC gameManagerSC;
    void Start()
    {
        EventManager.LightControl(gameManagerSC.lightControl);
        EventManager.HardModeOnOff(gameManagerSC.hardMod);
        EventManager.DominoSprite(gameManagerSC.dominoSprite);
    }

}

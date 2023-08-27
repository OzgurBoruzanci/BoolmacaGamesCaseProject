using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NEW GameManagerSC", menuName = "ScriptableObjects/GameManagerSC")]
public class GameManagerSC : ScriptableObject
{
    public bool hardMod;
    public bool lightControl;
    public bool dominoSprite;
    public bool music;
    public bool sound;
    public int score;
}

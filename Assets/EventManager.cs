using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class EventManager
{
    public static Action MouseClick;
    public static Action MouseDrag;
    public static Action SettledDownDomino;
    public static Action<bool> LightControl;
    public static Action DidNotSettle;
    public static Action<bool> HardModeOnOff;
    public static Action<bool> DominoSprite;
    public static Action<List<GameObject>> TableCells;
    public static Action<Sprite, Sprite> DominoSprites;
    public static Action NewDomino;
    public static Action CheckCell;
    public static Action<int> EarnPoints;
}
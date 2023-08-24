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
}
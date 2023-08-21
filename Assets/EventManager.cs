using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action MouseClick;
    public static Action MouseDrag;
    public static Action SettledDownDomino;
    public static Action<bool> LightControl;
}
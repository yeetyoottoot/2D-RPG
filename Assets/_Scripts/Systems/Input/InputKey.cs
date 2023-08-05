using System;
using UnityEngine;


public static class InputKey
{
    public static event Action<MouseAction, Vector3> MouseClickEvent;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoInit() => MonoHelper.OnUpdate += CheckForMouseClick;

    static void CheckForMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) { MouseClickEvent?.Invoke(MouseAction.LDown, Input.mousePosition); }
        else if (Input.GetMouseButtonUp(0)) { MouseClickEvent?.Invoke(MouseAction.LUp, Input.mousePosition); }
        else if (Input.GetMouseButton(0)) { MouseClickEvent?.Invoke(MouseAction.LHold, Input.mousePosition); }
    }
}

public enum MouseAction { LDown, LUp, LHold }


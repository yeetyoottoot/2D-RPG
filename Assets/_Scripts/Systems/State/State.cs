using System;
using System.Collections;
using UnityEngine;

public abstract class State
{
    #region REFERENCES

    protected DataManager Data => DataManager.Io;
    protected AudioManager Audio => AudioManager.Io;

    #endregion REFERENCES


    #region STATE SYSTEMS

    /// These state systems are organized in order of execution
    /// <summary>
    ///     Called by SetStateDirectly() and InitiateFade().
    /// </summary>
    protected void DisableInput()
    {
        //InputKey.RStickAltYEvent -= RAltYInput;
        InputKey.MouseClickEvent -= Clicked;
    }

    /// <summary>
    ///     Called by SetStateDirectly() and FadeOutToBlack().
    /// </summary>
    protected virtual void DisengageState()
    {
    }

    /// <summary>
    ///     Called by SetStateDirectly() and FadeOutToBlack(). Don't set new states here.
    /// </summary>
    protected virtual void PrepareState(Action callback)
    {
        callback();
    }

    /// <summary>
    ///     Called by SetSceneDirectly() and FadeInToScene().
    /// </summary>
    protected void EnableInput()
    {
        InputKey.MouseClickEvent += Clicked;
    }

    /// <summary>
    ///     Called by SetStateDirectly() and FadeInToScene(). OK to set new states here.
    /// </summary>
    protected virtual void EngageState()
    {
    }

    protected void SetStateDirectly(State newState)
    {
        DisableInput();
        DisengageState();

        newState.PrepareState(Initiate().StartCoroutine);

        IEnumerator Initiate()
        {
            yield return null;
            newState.EnableInput();
            newState.EngageState();
        }
    }

    protected void FadeToState(State newState)
    {
        ScreenFader fader = new();
        InitiateFade().StartCoroutine();
        return;

        IEnumerator InitiateFade()
        {
            DisableInput();
            yield return null;
            FadeOutToBlack().StartCoroutine();
        }

        IEnumerator FadeOutToBlack()
        {
            while (fader.Screen.color.a < .99f)
            {
                yield return null;
                fader.Screen.color += new Color(0, 0, 0, Time.deltaTime * 1.25f);
            }

            fader.Screen.color = Color.black;

            yield return null;
            newState.PrepareState(FadeInToScene().StartCoroutine);
        }

        IEnumerator FadeInToScene()
        {
            DisengageState();

            while (fader.Screen.color.a > .01f)
            {
                yield return null;
                fader.Screen.color -= new Color(0, 0, 0, Time.deltaTime * 2.0f);
            }

            fader.SelfDestruct();
            newState.EnableInput();
            newState.EngageState();
        }
    }

    #endregion STATE SYSTEMS


    #region INPUT

    protected virtual void ClickedOn(GameObject go) { }
    protected virtual void Clicked(MouseAction action, Vector3 mousePos)
    {
        if (action != MouseAction.LUp) return;

        if (Cam.Io.Camera.orthographic)
        {
            RaycastHit2D hitUI = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hitUI.collider != null && hitUI.collider.gameObject.TryGetComponent<Clickable>(out _))
            {
                ClickedOn(hitUI.collider.gameObject);
                return;
            }

            var hit = Physics2D.Raycast(Cam.Io.Camera.ScreenToWorldPoint(mousePos), Vector2.zero);
            if (hit.collider != null) ClickedOn(hit.collider.gameObject);
        }
        else
        {
            var hit = Physics2D.GetRayIntersection(Cam.Io.Camera.ScreenPointToRay(mousePos));
            var hitUI = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
                ClickedOn(hit.collider.gameObject);
            else if (hitUI.collider != null) ClickedOn(hitUI.collider.gameObject);
        }
    }

    #endregion INPUT 
}
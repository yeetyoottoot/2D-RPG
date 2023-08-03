using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Gamekit3D;

public class SceneTransitions : MonoBehaviour
{
    private static SceneTransitions instance;
     
    public static SceneTransitions MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneTransitions>();
            }
            return instance;
        }
    }

    public IEnumerator SceneTransition(string scene)
    {
        // black out scene before loading starts
        ScreenFader.BlackOutScene();

        yield return StartCoroutine(ScreenFader.FadeSceneOut(ScreenFader.FadeType.Loading));
        while (ScreenFader.IsFading)
            yield return null;

        SceneManager.LoadScene(scene);

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(ScreenFader.FadeSceneIn());
              
        while (ScreenFader.IsFading)
            yield return null;

    }

    public IEnumerator GameRestart(ScreenFader.FadeType s)
    {
        yield return StartCoroutine(ScreenFader.FadeSceneOut(s));
        while (ScreenFader.IsFading)
            yield return null;

        yield return new WaitForSeconds(6f);

        //UIManager.MyInstance.OpenTitleScreenCanvas();

        yield return StartCoroutine(ScreenFader.FadeSceneIn());

        while (ScreenFader.IsFading)
            yield return null;
    }
}

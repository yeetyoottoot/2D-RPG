using System.Collections.Generic;
using Gamekit3D;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string startingSceneName;
  
    private static GameManager instance;

    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }

    }

    public void StartOpeningSequence()
    {

        ExecuteSceneChange(startingSceneName);

    }

    public void ExecuteSceneChange(string sceneName)
    {
        //ScreenFader.Instance.loadingText.text = "Loading...";

        StartCoroutine(SceneTransitions.MyInstance.SceneTransition(sceneName));

    }
}

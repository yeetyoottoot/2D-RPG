using Gamekit3D;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

    public CanvasGroup[] menus;

    public GameObject closeButton;
    public GameObject quitButton;

    public bool menusEnabled = false;
    
    private CanvasGroup titleScreenCanvas;

    public void Awake()
    {
        titleScreenCanvas = Array.Find(menus, m => m.name == "TitleScreenCanvas");
    }

    // Update is called once per frame
    private void Update()
    {
        //ignore if title screen is open
        if (titleScreenCanvas.alpha == 1)
            return;

        //if (menusEnabled)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //        OpenCloseSystem();
        //}

    }

    public void CloseAllMenus()
    {
        foreach (CanvasGroup canvas in menus)
        {
            CloseSingle(canvas);
        }

        HideCursor();
    }

    public void OpenCloseSystem()
    {
        CanvasGroup menu = Array.Find(menus, m => m.name == "SystemMenu");

        OpenMenu(menu);
    }

    public void OpenMenu(CanvasGroup menu)
    {
        
        ShowCursor();

        menu.alpha = menu.alpha > 0 ? 0 : 1;
        menu.interactable = menu.interactable == true ? false : true;
        menu.blocksRaycasts = menu.blocksRaycasts == true ? false : true;
    }

    public void OpenTitleScreenCanvas()
    {
        ShowCursor();
        OpenSingle(Array.Find(menus, m => m.name == "TitleScreenCanvas"));

    }

    public void CloseTitleScreenCanvas()
    {
        HideCursor();
        CloseSingle(Array.Find(menus, m => m.name == "TitleScreenCanvas"));
    }

    public void NewGame()
    {
        CanvasGroup menu = Array.Find(menus, m => m.name == "SaveLoadDeleteGame");

        //ignore if SaveLoadDelete menu is already open
        if (menu.alpha == 0)
            GameManager.MyInstance.StartOpeningSequence();

        CloseTitleScreenCanvas();
    }

    public void OpenSettingsMenu(CanvasGroup canvasGroup)
    {
        CanvasGroup menu = Array.Find(menus, m => m.name == "SaveLoadDeleteGame");

        //ignore if SaveLoadDelete menu is already up
        if (menu.alpha == 0)
        {
            OpenClose(canvasGroup);

        }
    }

    public void OpenSettingsTitleMenu(CanvasGroup canvasGroup)
    {
        CanvasGroup menu = Array.Find(menus, m => m.name == "SaveLoadDeleteGame");

        //ignore if SaveLoadDelete menu is already up
        if (menu.alpha == 0)
            OpenClose(canvasGroup);
    }

    public void CloseSettingsMenu(CanvasGroup canvasGroup)
    {
        CloseSingle(canvasGroup);
    }

    public void SaveLoadDeleteMenu(String action)
    {
        CanvasGroup menu = Array.Find(menus, m => m.name == "SaveLoadDeleteGame");


        CanvasGroup menu2 = Array.Find(menus, m => m.name == "Settings");

        //ignore if SaveLoadDelete or Settings menu is already open
        if (menu.alpha == 0 & menu2.alpha == 0)
        {
            if (action == "GameOver")
            {
                closeButton.SetActive(false);
                quitButton.SetActive(true);

                action = "Load";
            }
            else
            {
                closeButton.SetActive(true);
                quitButton.SetActive(false);
            }

        }
    }

    public void OpenClose(CanvasGroup canvasGroup)
    {
        GetComponent<AudioSource>().Play(0);

        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.interactable = canvasGroup.interactable == true ? false : true;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;

    }

    public void OpenSingle(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void CloseSingle(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void HideCursor()
    {
        //UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        //UnityEngine.Cursor.visible = false;
    }

    public void ShowCursor()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }

    public void ShowCreditsFromTitleScreen()
    {
        CanvasGroup menu = Array.Find(menus, m => m.name == "SaveLoadDeleteGame");

        //ignore if SaveLoadDelete menu is already open
        if (menu.alpha == 0)
        {
            HideCursor();

            StartCoroutine(SceneTransitions.MyInstance.GameRestart(ScreenFader.FadeType.Credits));

        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
                 Application.Quit();
#endif
    }

}


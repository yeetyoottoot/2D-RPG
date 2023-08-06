using UnityEngine;

public class StatCanvas : MonoBehaviour
{
    private static StatCanvas instance;

    public static StatCanvas MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StatCanvas>();
            }

            return instance;
        }
    }

    public void Hide()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void Show()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

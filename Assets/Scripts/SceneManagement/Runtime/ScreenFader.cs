using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit3D
{
    public class ScreenFader : MonoBehaviour
    {
        public enum FadeType
        {
            Black, Loading, GameOver, Credits
        }

        public static ScreenFader Instance
        {
            get
            {
                if (s_Instance != null)
                    return s_Instance;

                s_Instance = FindObjectOfType<ScreenFader>();

                if (s_Instance != null)
                    return s_Instance;

                Create();

                return s_Instance;
            }
        }

        public static bool IsFading
        {
            get { return Instance.m_IsFading; }
        }

        protected static ScreenFader s_Instance;

        public static void Create()
        {
            ScreenFader controllerPrefab = Resources.Load<ScreenFader>("ScreenFader");
            s_Instance = Instantiate(controllerPrefab);
        }


        public CanvasGroup faderCanvasGroup;
        public CanvasGroup loadingCanvasGroup;
        public CanvasGroup gameOverCanvasGroup;
        public CanvasGroup creditsCanvasGroup;
        public Text faderText;
        public Text gameOverText;
        public Text loadingText;
        public Text creditsText;

        public float fadeDuration = 1f;

        protected bool m_IsFading;

        const int k_MaxSortingLayer = 32767;

        void Awake()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        protected IEnumerator Fade(float finalAlpha, CanvasGroup canvasGroup)
        {
            m_IsFading = true;
            canvasGroup.blocksRaycasts = true;
            float fadeSpeed = Mathf.Abs(canvasGroup.alpha - finalAlpha) / fadeDuration;
            while (!Mathf.Approximately(canvasGroup.alpha, finalAlpha))
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, finalAlpha,
                    fadeSpeed * Time.deltaTime);
                yield return null;
            }
            canvasGroup.alpha = finalAlpha;
            m_IsFading = false;
            canvasGroup.blocksRaycasts = false;
        }

        public static void BlackOutScene()
        {
            Instance.loadingCanvasGroup.gameObject.SetActive(true);
            Instance.loadingCanvasGroup.alpha = 1;
        }

        public static IEnumerator FadeSceneIn()
        {
            CanvasGroup canvasGroup;
            Text text;

            if (Instance.faderCanvasGroup.alpha > 0.1f)
            {
                canvasGroup = Instance.faderCanvasGroup;
                text = Instance.faderText;
            }
            else if (Instance.gameOverCanvasGroup.alpha > 0.1f)
            {
                canvasGroup = Instance.gameOverCanvasGroup;
                text = Instance.gameOverText;
            }
            else if (Instance.creditsCanvasGroup.alpha > 0.1f)
            {
                canvasGroup = Instance.creditsCanvasGroup;
                text = Instance.creditsText;
            }
            else
            {
                canvasGroup = Instance.loadingCanvasGroup;
                text = Instance.loadingText;
            }

            text.enabled = false;

            yield return Instance.StartCoroutine(Instance.Fade(0f, canvasGroup));

            canvasGroup.gameObject.SetActive(false);
        }

        public static IEnumerator FadeSceneOut(FadeType fadeType = FadeType.Black)
        {
            CanvasGroup canvasGroup;
            Text text;

            switch (fadeType)
            {
                case FadeType.Black:
                    canvasGroup = Instance.faderCanvasGroup;
                    text = Instance.faderText;
                    text.enabled = false;
                    break;
                case FadeType.GameOver:
                    canvasGroup = Instance.gameOverCanvasGroup;
                    text = Instance.gameOverText;
                    text.enabled = false;
                    break;
                case FadeType.Credits:
                    canvasGroup = Instance.creditsCanvasGroup;
                    text = Instance.creditsText;
                    text.enabled = false;
                    break;
                default:
                    canvasGroup = Instance.loadingCanvasGroup;
                    text = Instance.loadingText;
                    text.enabled = false;
                    break;
            }

            canvasGroup.gameObject.SetActive(true);

            yield return Instance.StartCoroutine(Instance.Fade(1f, canvasGroup));

            yield return new WaitForSeconds(1f);

            text.enabled = true;
        }
    }
}

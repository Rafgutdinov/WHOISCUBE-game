using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 1f;

    private static SceneTransition instance;
    private bool isTransitioning;

    private void Awake()
    {
        // Защита от дублирования
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Проверяем, не является ли объект уже "неуничтожимым"
        if (gameObject.scene.buildIndex != -1) // Если объект не в DontDestroyOnLoad сцене
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!isTransitioning) return;
        StartCoroutine(FadeInCoroutine());
    }

    public void StartTransition(int sceneIndex)
    {
        if (isTransitioning) return;
        StartCoroutine(TransitionCoroutine(sceneIndex));
    }

    private IEnumerator TransitionCoroutine(int sceneIndex)
    {
        isTransitioning = true;

        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeOutTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }

    private IEnumerator FadeInCoroutine()
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeInTime);
        isTransitioning = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            StartTransition(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
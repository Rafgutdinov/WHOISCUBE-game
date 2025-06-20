using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    [Tooltip("Имя сцены для загрузки")]
    public string sceneName;

    [Tooltip("Тег объекта, который может активировать загрузку")]
    public string triggerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
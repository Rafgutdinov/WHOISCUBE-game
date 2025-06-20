using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startButt : MonoBehaviour
{
    public string SceneName;
    public void OnButton()
    {
        SceneManager.LoadScene(SceneName);
    }
}

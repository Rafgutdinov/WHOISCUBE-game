using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public GameObject TextM1;
    public GameObject TextM2;
    public GameObject TextM3;
    public GameObject LoadBlock;
    void Update()
    {
        float playtime = Time.timeSinceLevelLoad;

        if (playtime > 1f)
        {
            TextM1.SetActive(false);
            TextM2.SetActive(true);
        }

        if (playtime > 3f)
        {
            TextM2.SetActive(false);
            TextM3.SetActive(true);
        }

        if (playtime > 6f)
        {
            LoadBlock.SetActive(false);
        }
    }
}

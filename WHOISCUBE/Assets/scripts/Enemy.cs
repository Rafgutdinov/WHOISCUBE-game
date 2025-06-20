using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject FailCan;
    public GameObject Enemys;
    public GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FailCan.SetActive(true);

            player.SetActive(false);
        }
    }
}

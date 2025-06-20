using Unity.VisualScripting;
using UnityEngine;

public class Respawn: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(0, 1.1f, 0);
        }
    }
}

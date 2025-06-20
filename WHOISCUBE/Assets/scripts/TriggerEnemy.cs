using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    [Header("Триггер и враг")]
    public Vector3 trigRas = new Vector3(14.26f, 0.35f, 1.32f);
    public GameObject enemyTrig;
    public GameObject trigDel;  // Удаляется при касании
    public void OnTriggerEnter(Collider other)
    {
        // Если игрок задел trigDel
        if (other.CompareTag("Player") && gameObject == trigDel)
        {
            if (enemyTrig != null)
                enemyTrig.transform.position = trigRas;

            trigDel.SetActive(false);
        }
    }
}
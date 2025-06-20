using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RestartButt : MonoBehaviour
{
    [System.Serializable]
    public class EnemyTriggerPair
    {
        public GameObject enemyTrig;
        public GameObject trigDel;
        public Vector3 respawnPosition;
    }

    public List<EnemyTriggerPair> enemyTriggers = new List<EnemyTriggerPair>();
    public Coin[] coins; // Массив всех монет на сцене
    public TextMeshProUGUI coinText;
    public GameObject failCanvas;
    public GameObject player;
    public Vector3 playerRespawnPosition = new Vector3(0, 1.1f, 0);

    private void Start()
    {
        // Находим все монеты на сцене при старте
        coins = FindObjectsOfType<Coin>();
    }

    public void OnButton()
    {
        // Сброс игрока
        player.transform.position = playerRespawnPosition;
        player.SetActive(true);
        failCanvas.SetActive(false);

        // Сброс монет
        Coin.ResetCoins();
        coinText.text = "Монет: 0";

        // Восстанавливаем все монеты
        foreach (Coin coin in coins)
        {
            if (coin != null)
            {
                coin.ResetCoin();
            }
        }

        // Сброс триггеров и врагов
        foreach (var pair in enemyTriggers)
        {
            if (pair.trigDel != null) pair.trigDel.SetActive(true);
            if (pair.enemyTrig != null)
            {
                pair.enemyTrig.SetActive(true);
                pair.enemyTrig.transform.position = pair.respawnPosition;
            }
        }

        Time.timeScale = 1f;
    }
}
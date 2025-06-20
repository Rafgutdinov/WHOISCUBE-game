using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public static int coinsInt = 0;
    public AudioClip coinAudioClip;
    public GameObject coinVisual;

    private AudioSource audioSource;
    private bool isCollected = false;
    private Collider coinCollider;
    private Vector3 originalPosition;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        coinCollider = GetComponent<Collider>();
        originalPosition = transform.position;

        if (coinVisual == null)
            coinVisual = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            CollectCoin();
        }
    }

    public void CollectCoin()
    {
        isCollected = true;
        coinVisual.SetActive(false);
        coinCollider.enabled = false;

        coinsInt++;
        UpdateCoinText();

        if (coinAudioClip != null)
        {
            audioSource.PlayOneShot(coinAudioClip);
        }
    }

    public void ResetCoin()
    {
        isCollected = false;
        coinVisual.SetActive(true);
        coinCollider.enabled = true;
        transform.position = originalPosition;
    }

    void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = "Монет: " + coinsInt;
    }

    public static void ResetCoins()
    {
        coinsInt = 0;
    }
}
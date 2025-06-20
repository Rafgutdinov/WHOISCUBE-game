using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueUI;       // UI-панель диалога
    public TextMeshProUGUI dialogueText;          // Текст диалога
    public string[] dialogueLines;     // Реплики
    public GameObject StartDial;

    private int currentLine = 0;
    private bool isDialogueActive = false;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
                StartDialogue();
            else
                NextLine();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            StartDial.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartDial.SetActive(false);
            playerInRange = false;
            if (isDialogueActive)
                EndDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
        dialogueUI.SetActive(true);
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
            dialogueText.text = dialogueLines[currentLine];
        else
            EndDialogue();
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);
        StartDial.SetActive(false);
    }
}
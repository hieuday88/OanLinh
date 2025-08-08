using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public int currentLine = 0;
    public float typingSpeed;
    void OnEnable()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == dialogueLines[currentLine])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLine];
            }
        }
    }
    public void StartDialogue()
    {
        currentLine = 0;
        dialogueText.text = "";
        StartCoroutine(TypeLine());
        PlayerInteraction.Instance.isBusy = true;
    }

    IEnumerator TypeLine()
    {
        foreach (char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextLine()
    {
        if (currentLine < dialogueLines.Length - 1)
        {
            currentLine++;
            dialogueText.text = "";
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        currentLine = 0;
        PlayerInteraction.Instance.isBusy = false;
    }
}

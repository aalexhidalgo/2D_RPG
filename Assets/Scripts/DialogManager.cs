using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogTextBox;
    public bool isDialogActive;

    [TextArea]
    public string[] dialogLines;
    public int currentDialogLine;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
        HideDialog();        
    }

    private void Update()
    {
        if(isDialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLine++;

            if (currentDialogLine >= dialogLines.Length)
            {
                HideDialog();
            }
            else
            {
                dialogTextBox.text = dialogLines[currentDialogLine];
            }

        }
    }

    public void ShowDialog (string[] lines)
    {
        currentDialogLine = 0;
        dialogLines = lines;
        isDialogActive = true;
        dialogPanel.SetActive(isDialogActive);
        dialogTextBox.text = dialogLines[currentDialogLine];
        playerControllerScript.isTalking = true;
    }

    public void HideDialog()
    {
        playerControllerScript.isTalking = false;
        isDialogActive = false;
        dialogPanel.SetActive(isDialogActive);
    }
}

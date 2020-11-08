using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class TextUIManager : MonoBehaviour
{
    private Transform uiGroup;
    private Text textBox;
    private DialogueData currentDialogue;
    private int currentIndex = 0;

    public TextUIManager(GroupTextUI data) 
    {
        uiGroup = data.GetUIGroup();
        textBox = data.GetTextBox();
        uiGroup.gameObject.SetActive(false);
    }
    public void InitializeUIManager() 
    {
        GroupTextUI temp = gameObject.GetComponentInChildren<GroupTextUI>();
        uiGroup = temp.GetUIGroup();
        textBox = temp.GetTextBox();
        uiGroup.gameObject.SetActive(false);
    }
    // add function to activate UI when data is given
    // add function to ddeactivate UI when data runs out

    public void ActivateDialogueScreen() 
    {
        currentIndex = 0;
        uiGroup.gameObject.SetActive(true);
        textBox.text = currentDialogue.GetDialogueDataByIndex(currentIndex);
    }

    public void DeactivateDialogueScreen() 
    {
        uiGroup.gameObject.SetActive(false);
        currentDialogue = null;
    }
    public void CallDialogue(DialogueData dialogue) 
    {
        if (dialogue != null)
        {
            currentDialogue = dialogue;
            ActivateDialogueScreen();
        }

        else 
        {
            Debug.LogError("Dialogue is null!");
        }
    }

    public void NextDialogue() 
    {
        if (currentDialogue != null) 
        {
            string temp = currentDialogue.GetDialogueDataByIndex(++currentIndex);
            if (temp != null)
            {
                textBox.text = temp;
            }
            else
            {
                DeactivateDialogueScreen();
            }
        }
    }

    public void PrevDialogue() 
    {
        if (currentDialogue != null) 
        {
            string temp = currentDialogue.GetDialogueDataByIndex(--currentIndex);
            if (temp != "MIN")
            {
                textBox.text = temp;
            }
            else
            {
                Debug.LogWarning("MIN DIALOGUE");
            }
        }
     
    }


}

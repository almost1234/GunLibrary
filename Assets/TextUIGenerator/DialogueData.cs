using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData
{
    private string eventName;
    private int[] eventIndex;
    private string[] dialogueData;

    public DialogueData(string eventName, int[] eventIndex, string[] dialogueData)
    {
        this.eventName = eventName;
        this.eventIndex = eventIndex;
        this.dialogueData = dialogueData;
    }

    public string GetDialogueKey() 
    {
        return TextDataManager.ConvertEventToKey(eventName, eventIndex);
    }

    public bool IfIndexDataPossible(int index) 
    {
        return index < dialogueData.Length && 0 <= index;
    }

    public string GetDialogueDataByIndex(int index) 
    {
        if (IfIndexDataPossible(index))
        {
            return dialogueData[index];
        }

        else if(index == 0)
        {
            return "MIN";
        }

        return null;
    }
}

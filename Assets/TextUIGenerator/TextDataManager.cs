using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TextDataManager : MonoBehaviour
{
    private TextDataManager() { }
    public static  TextDataManager Instance;
    private TextUIManager textUIManager;

    private Dictionary<string, DialogueData> textDatabase = new Dictionary<string, DialogueData>();

    private void Awake()
    {
        Instance = this;
        textUIManager = new TextUIManager(gameObject.GetComponentInChildren<GroupTextUI>());
        string[] tempData = TextAssetTool.ReadTextAssetData("Text/sampleDialogue");
        foreach(string data in tempData) 
        {
            string[] seperatedData = data.Split('-');
            foreach (string datak in seperatedData) Debug.Log(datak);
            if (seperatedData.Length == 3)
            {
                DialogueData dialogueData = new DialogueData(seperatedData[0], TextAssetTool.ConvertNumberStringToInt(seperatedData[1], ':'), seperatedData[2].Split(';'));
                AddEventTextToDatabase(dialogueData.GetDialogueKey(), dialogueData);
                Debug.LogWarning(string.Format("The key {0} is added", dialogueData.GetDialogueKey()));
            }
            else 
            {
                Debug.LogError("GO FUCK URSELF");
            }
        }
        Debug.LogWarning("TextDataManager initialized");
    }

    public void ControlDialogue(string textInput) 
    {
        switch (textInput) 
        {
            case "else":
                textUIManager.CallDialogue(GetEventText("event-1/1/1/1/"));
                break;
            case "c":
                textUIManager.NextDialogue();
                break;
            case "z":
                textUIManager.PrevDialogue();
                break;
        }
    }

    public static string ConvertEventToKey(string eventName, params int[] eventIndex) 
    {
        string Key = eventName + "-";
        foreach (int index in eventIndex) Key += index.ToString() + "/";
        return Key;
    }

    public DialogueData GetEventText(string eventName, params int[] eventIndex) 
    {
        string keyGenerated = ConvertEventToKey(eventName, eventIndex);
        return GetEventText(keyGenerated);
    }
    public DialogueData GetEventText(string key) 
    {
        if (textDatabase.ContainsKey(key))
        {
            return textDatabase[key];
        }
        else 
        {
            return null;
        }

    }

    public void AddEventTextToDatabase(string data, string eventName, params int[] eventIndex) 
    {
        string keyGenerated = ConvertEventToKey(eventName, eventIndex);
        AddEventTextToDatabase(keyGenerated, data);
    }

    public void AddEventTextToDatabase(string key, DialogueData data) 
    {
        if (!textDatabase.ContainsKey(key))
        {
            textDatabase.Add(key, data);
        }

        else 
        {
            Debug.LogWarning(string.Format("The key {0} is already added into it", key));
        }
    }
    
}

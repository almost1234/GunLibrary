using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupTextUI : MonoBehaviour
{
    //temp and i dont know how to make this managable in the future.
    public Transform uiGroup;
    public Text textBox;

    private void Awake()
    {
        uiGroup = gameObject.GetComponent<Transform>();
        textBox = gameObject.GetComponentInChildren<Text>();
    }

    public Text GetTextBox() 
    {
        return textBox;
    }

    public Transform GetUIGroup() 
    {
        return uiGroup;
    }
}

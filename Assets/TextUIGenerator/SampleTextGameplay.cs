using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTextGameplay : MonoBehaviour
{
    public TextDataManager idk;

    public void Start()
    {
        idk = TextDataManager.Instance;
    }
    public void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            idk.ControlDialogue("else");
        }
        else if (Input.GetKeyDown("c"))
        {
            idk.ControlDialogue("c");
        }
        else if (Input.GetKeyDown("z")) 
        {
            idk.ControlDialogue("z");
        }
    }
}

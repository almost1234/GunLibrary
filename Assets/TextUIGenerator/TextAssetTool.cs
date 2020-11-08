using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAssetTool 
{
    public static string[] ReadTextAssetData(string filePath)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(filePath);

        if (textAsset == null) return null;

        string textData = textAsset.text;

        string[] rows = textData.Split('\n');

        return rows;
    }

    public static int[] ConvertNumberStringToInt(string numberString, char seperator) //temp cuz i suck
    {
        string[] tempData = numberString.Split(seperator);
        int[] temp = new int[tempData.Length];
        for (int i = 0; i < tempData.Length; i++) 
        {
            temp[i] = int.Parse(tempData[i]);
        }
        return temp;
    }
}

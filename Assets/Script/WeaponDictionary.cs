using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Xml.Serialization;
using UnityEngine;

public class WeaponDictionary : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, BaseWeapon>> weaponData = new Dictionary<string, Dictionary<string, BaseWeapon>>();
    [SerializeField]
    private string[] weaponName;
    public static WeaponDictionary Instance;

    private void Awake()
    {
        Instance = this;
        InitializeWeaponData();
    }
    private WeaponDictionary() { }
    private void InitializeWeaponData() 
    {
        foreach(string name in weaponName) 
        {
            string path = "Weapons/" + name;
            GameObject tempWeapon = Resources.Load<GameObject>(path);
            BaseWeapon reference = tempWeapon.GetComponent<BaseWeapon>();
            if (tempWeapon != null) 
            {
                string weaponType = reference.GetType().ToString();
                if (!weaponData.ContainsKey(weaponType)) 
                {
                    weaponData.Add(weaponType, new Dictionary<string, BaseWeapon>());
                }
                weaponData[weaponType].Add(name, reference);
                Debug.Log(name + "Added");
            }

            else 
            {
                Debug.Log("CANT FIND WEAPON IN RESOURCE!");
            }
        }
        Debug.Log("Data initialized");
    }

    private BaseWeapon GetBaseWeapon<T>(string weaponName) where T : BaseWeapon
    {
        Dictionary<string, BaseWeapon> firstCheck = weaponData[typeof(T).ToString()];
        if (firstCheck != null)
        {
            if (firstCheck[weaponName] != null)
            {
                return firstCheck[weaponName];
            }

            else
            {
                Debug.LogError("NAME OF WEAPON DOES NOT EXIST");
                return null;
            }
        }

        else 
        {
            Debug.LogError(typeof(T).ToString() + " CATEGORY DOESNT EXIST");
            return null;
        }
    }
    //temp adjustment till i find more functionality
    public BaseWeapon GetWeapon<T>(string weaponName) where T : BaseWeapon
    {
        return  GetBaseWeapon<T>(weaponName);
    }

}

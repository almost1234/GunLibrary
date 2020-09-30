using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BaseWeapon weapon;
    public float speed;
    public WeaponDictionary TestVar;
    public Transform hand;

    private void Start()
    {
        TestVar = WeaponDictionary.Instance;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            weapon.AttackMethod();
        }
        if (Input.GetKey("space")) 
        {
            weapon.IdleMethod();
        }
    }

    private void Movement() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.position += new Vector3(z, 0, x) * speed;
    }

    public void ChangeWeapon() //temp hardcode
    {
        string weaponName = "M16";
        foreach (Transform child in hand) 
        {
            Destroy(child.gameObject);
        }
        BaseWeapon temp = TestVar.GetWeapon<Gun>(weaponName);
        weapon = Instantiate(temp.gameObject, hand).GetComponent<BaseWeapon>();
    }
}

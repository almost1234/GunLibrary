using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BaseWeapon weapon;
    public float speed;

    private void Update()
    {
        Debug.Log("MOUSE HOLD");
        weapon.weaponState = !Input.GetMouseButton(0) ? WeaponState.attack : WeaponState.idle;
        Movement();

    }

    private void Movement() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.position += new Vector3(z, 0, x) * speed;
    }
}

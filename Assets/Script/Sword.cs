using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : BaseWeapon
{
    public Vector3 boxScale;

    private void Update()
    {
        Gizmos.DrawCube(transform.position, boxScale);
    }
    protected override void AttackMethod()
    {
        //insert animation for sword to swing
    }

    protected override void IdleMethod()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) 
        {
            Collider[] tempCollider = Physics.OverlapBox(transform.position, boxScale);
            foreach (Collider data in tempCollider) 
            {
                Debug.Log(data.name);
            }
        }
    }
}

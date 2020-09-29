using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public float attackRate;
    public float attackDamage;
    public WeaponState weaponState = WeaponState.idle; //temporary
    
    private void Update()
    {
        switch (weaponState) 
        {
            case WeaponState.idle:
                AttackMethod();
                Debug.Log("attack");
                break;
            case WeaponState.attack:
                IdleMethod();
                Debug.Log("idle");
                break;
        }
    }

    protected abstract void AttackMethod();

    protected abstract void IdleMethod();
}

public enum WeaponState 
{
    attack, idle
}
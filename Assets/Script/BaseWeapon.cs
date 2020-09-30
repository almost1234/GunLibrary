using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public float attackRate;
    public float attackDamage;
    public WeaponState weaponState = WeaponState.idle; //temporary
    

    public abstract void AttackMethod();

    public abstract void IdleMethod();
}

public enum WeaponState 
{
    attack, idle
}
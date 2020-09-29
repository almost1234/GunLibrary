using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : BaseWeapon
{
    public float horizontalRecoil;
    public float verticalRecoil;
    public float shootTime = 0f;
    public float recoilMaxTime;
    public float maxBullet;
    private float currentBullet;
    public Transform muzzlePoint;
    public Transform gunPoint;

    public float fireTime;
    public bool isRaycastShooting = false;

    public Bullet bullet;
    public GameObject OnImpactParticle;
    public float forceImpact;

    private void Awake()
    {
        currentBullet = maxBullet;
        fireTime = attackRate;
    }

    public void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(ray.direction);
        Gizmos.DrawRay(ray.origin, ray.direction);
        Debug.DrawRay(ray.origin, ray.direction);
    }

    protected override void AttackMethod()
    {
        if (attackRate <= fireTime && currentBullet > 0)
        {
            fireTime = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (isRaycastShooting) 
                {
                    case true:
                        RaycastShooting(hit);
                        break;
                    case false:
                        PhysicsShooting(hit);
                        break;
                }
            }
            currentBullet--;
        }
        else 
        {
            fireTime += Time.deltaTime;
            shootTime += Time.deltaTime;
        }
        
    }

    protected override void IdleMethod()
    {
        Reload();
    }

    private void Reload() 
    {
        //insert reloading animation
        currentBullet = maxBullet;
    }
    private void RaycastShooting(RaycastHit hit) 
    {
        if (hit.collider != null) 
        {
            Destroy(Instantiate(OnImpactParticle, hit.point, Quaternion.LookRotation(hit.normal)), 2);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * forceImpact);
            }
        }
    }
    private void PhysicsShooting(RaycastHit hit) 
    {
        Debug.Log("GENERATE THE FUKIN BULLET");
        bullet.damage = attackDamage;
        bullet.direction = hit.point - muzzlePoint.position;
        Instantiate(bullet.gameObject, muzzlePoint.position, Quaternion.LookRotation(hit.point));
    }

    private Vector3 RecoilSetting(Vector3 hitPosition) 
    {
        float scaling = (Mathf.Min(shootTime, recoilMaxTime) / recoilMaxTime);
        return hitPosition + new Vector3(Random.Range(-horizontalRecoil, horizontalRecoil) * scaling, verticalRecoil * scaling, Random.Range(-horizontalRecoil, horizontalRecoil) * scaling);
    }
}

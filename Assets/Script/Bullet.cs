using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float force;
    public Rigidbody rb;

    public Vector3 direction;

    public void Update()
    {
        if (direction != null) { transform.position += direction * 0.2f; }
        
    }
    public void Hammered() 
    {
        rb.AddForce(transform.forward * force);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null) 
        {

            other.attachedRigidbody.AddForceAtPosition(Vector3.right * 200f, other.ClosestPointOnBounds(transform.position));
            Destroy(this);
        }
        
    }
}

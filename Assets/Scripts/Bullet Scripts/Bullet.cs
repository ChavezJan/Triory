using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float bulletDamage = 10f;
    public float timeToDie = 5;
    public float distanceToDie = 100;
    public Rigidbody rb;

    public Vector3 initialPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        initialPoint = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        float distanceTravel =  Vector3.Distance(initialPoint, gameObject.transform.position);
        if(distanceTravel >= distanceToDie)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider hitInfo) 
    {
        if(hitInfo.name != "Bullet(Clone)" && hitInfo.name != "pCone1")
        {
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
            if(enemy != null) 
            {
                enemy.TakeDamage(bulletDamage);
            }
            Destroy(gameObject);   
        }
    }

}

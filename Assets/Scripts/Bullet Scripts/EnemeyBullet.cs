using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyBullet : MonoBehaviour
{
     public float bulletSpeed = 20f;
    public float bulletDamage = 10f;
    public float timeToDie = 5;
    public float distanceToDie = 100;
    public Rigidbody rb;
    public GameObject[] Players;
    public GameObject Player;

    public Vector3 initialPoint;

    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        Player = Players[0];
        Vector3 direction = (Player.transform.position - this.transform.position).normalized;
        Debug.Log(direction);
        rb.velocity = direction * bulletSpeed;
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


        if(hitInfo.name == "pCone1")
        {
             
            Player.GetComponent<PlayerController>().takePlayerHP(bulletDamage);
            
            Destroy(gameObject);   
        }
    }

}

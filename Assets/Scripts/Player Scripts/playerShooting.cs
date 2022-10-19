using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerShooting : MonoBehaviour
{


    //Shooting Test
    public Transform firePoint;
    public GameObject bullet;
    public LineRenderer lineRenderer;

    public float bulletRange = 100f;
    public float bulletDamage = 10f;
    public int shootType = 1;
    /*
        1 - bullet prefab
        2 - Raycast
    */

    //Player DK
    public float shotBulletValue;
    //Enemy Damage
    public float shotBulletDamages;
    public float timeToRecoverPulse;
    public bool pulseUsed = false;

    DateTime pulseSpendDateTime;
    float timePassed;

    playerHealthAmmo pha;

    public GameObject pause;

    
    // Start is called before the first frame update
    void Start()
    {
        pha = FindObjectOfType<playerHealthAmmo>();  

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Cancel") > 0)
        {
            pause.SetActive(true);
        }
        if(Input.GetAxisRaw("1") > 0)
        {
            shootType = 1;
        }
        if(Input.GetAxisRaw("2") > 0)
        {
            shootType = 2;
        }


        if(Input.GetAxisRaw("Fire1") > 0)
        {   
            if(shootType == 2)
            {
                lineRenderer.enabled = true;
            }
            Shoot();
        }
        else
        {
            if(shootType ==2)
            {
                lineRenderer.enabled = false;
            }
        }
        if(Input.GetAxisRaw("Fire3") > 0 && pulseUsed == false)
        {   
            pulseUsed = true;
            pulseSpendDateTime = System.DateTime.Now;
            Pulse();
        }
        if(pulseUsed == true)
        {
            ReoverPulseWithTime();
            Debug.Log("pulse used please wait");
        }
    }

    void Shoot()
    {
    
        //shooting logic
        float healthAmmo = pha.getHealthAmmo();
     
        if(healthAmmo > 10)
        {
            
            switch (shootType)
            {
                case 2:
                    
                    // Raycast
                    RaycastHit hitInfo; 
                    if(Physics.Raycast(firePoint.position, firePoint.transform.right, out hitInfo, bulletRange))
                    {
                        Debug.Log(hitInfo.transform.name);
                        EnemyHealth enemy = hitInfo.transform.GetComponent<EnemyHealth>();
                        if(enemy != null)
                        {
                            enemy.TakeDamage(bulletDamage);
                        }

                        lineRenderer.SetPosition(0,firePoint.position);
                        lineRenderer.SetPosition(1,hitInfo.point);
                    }
                    else
                    {
                        lineRenderer.SetPosition(0,firePoint.position);
                        lineRenderer.SetPosition(1,firePoint.position+firePoint.right*100);
                    }
                    
                    break;
                case 1:
                    
                    // Bullet Prefab
                    Instantiate(bullet,firePoint.position,firePoint.rotation);
                    
                    break;
                default:
                    
                    // Bullet Prefab
                    Instantiate(bullet,firePoint.position,firePoint.rotation);
                    
                    break;
            }
        }

        pha.lostBullets(shotBulletValue);
    }

    void Pulse()
    {
        Debug.Log("ssshhiiiiuuummmmm");

        

    }
    void ReoverPulseWithTime()
    {
        timePassed = (float)(System.DateTime.Now - pulseSpendDateTime).TotalSeconds;

        if(timePassed >= timeToRecoverPulse && pulseUsed == true)
        {
            pulseUsed = false;
        }
    }
}

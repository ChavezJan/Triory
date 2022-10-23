using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek : MonoBehaviour
{

    public GameObject target;
    public float enemySpeed = 5f;
    public float distanceToFollow = 20f;
    public float distanceToStop = 10f;
    public bool enemyShoot = false;
    public int floorLevel = 2;

    public Transform firePoint;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveSeek();
        
    }

    void MoveSeek()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 agentPos = transform.position;
        Vector3 distance = targetPos - agentPos;
        float distanceFloat = Vector3.Distance(targetPos,agentPos);
        Vector3 velocity = distance.normalized * enemySpeed;
        int playerFloorLevel = target.GetComponent<PlayerController>().getLevel();

        if (distanceToFollow > distanceFloat && distanceFloat > distanceToStop && enemyShoot && floorLevel == playerFloorLevel)
        {
            transform.position += velocity* Time.deltaTime;
            shoot();

        }
        if (distanceToFollow > distanceFloat && !enemyShoot && floorLevel == playerFloorLevel)
        {
            if(distanceFloat <7)
            {
                transform.position += (velocity* Time.deltaTime)*1.3f;
            }
            else
            {
                transform.position += velocity* Time.deltaTime;
            }
        }
    }
    void shoot()
    {
        Instantiate(bullet,firePoint.position,firePoint.rotation);
    }

    void OnTriggerEnter(Collider hitInfo) 
    {


        if(hitInfo.name == "pCone1")
        {
             
            
            target.GetComponent<PlayerController>().takePlayerHP(10);
            
            
            Destroy(gameObject);   
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shoot()
    {
        Instantiate(bullet,firePoint.position,firePoint.rotation);
    }
}

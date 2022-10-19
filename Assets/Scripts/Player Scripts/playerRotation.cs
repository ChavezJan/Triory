using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotation : MonoBehaviour
{
    public GameObject player;

    void FixedUpdate() {

        // Physics Calculations


        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotation = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f,rotation);        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    private int spacingInFaces = 70;
    private bool switchingUp = false;
    private bool switchingDown = false;

    public int floorLevel = 2;

    public float moveSpeed;
    public Rigidbody rb;

    private Vector2 moveDirection;      

    public GameObject takeHit;

    // Update is called once per frame
    void Update()
    {
        // Processing inputs  
        ProcessingInputs();

        // Jump to next face
        if (Input.GetAxisRaw("Jump") > 0 && switchingUp == false && player.transform.position.z < (60))
        {
            switchingUp = true;
            FaceUp();
        }
        if (Input.GetAxisRaw("Jump") < 1 )
        {
            switchingUp = false;
        }
        
        // Jump to down face
        if (Input.GetAxisRaw("Fire2") > 0 && switchingDown == false && player.transform.position.z > (-70))
        {
            switchingDown = true;
            FaceDown();
        }
        if (Input.GetAxisRaw("Fire2") < 1 )
        {
            switchingDown = false;
        }
        
    }

    void FixedUpdate() {

        // Physics Calculations
        Move();
    }

    void ProcessingInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY).normalized;

    }

    void FaceUp()
    {
        floorLevel++;
        Transform t = player.transform;
        t.position = new Vector3(t.position.x, t.position.y, t.position.z + spacingInFaces);
    }
    void FaceDown()
    {
        floorLevel--;
        Transform t = player.transform;
        t.position = new Vector3(t.position.x, t.position.y, t.position.z - spacingInFaces);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed,moveDirection.y * moveSpeed);
    }

    public int getLevel()
    {
        return floorLevel;
    }

    public void takePlayerHP(int hitPlayer)
    {
        takeHit.GetComponent<playerHealthAmmo>().takeDamage(hitPlayer);   
    }

}


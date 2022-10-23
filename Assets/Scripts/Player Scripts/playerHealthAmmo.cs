using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerHealthAmmo : MonoBehaviour
{

    //For testing
    public bool takeHit = false;

    //Player
    public GameObject triPlayer;

    public int levelOfHealthAmmo;
    public int rangeOfHealthAmmo;

    public float maxHealthAmmo;
    public float healthAmmo;

    public float timeToRecoverHealthAmmo;

    DateTime healthSpendDateTime;
    float timePassed;

    updateHealth updateTXT;

    //Canvas Game Over
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        updateTXT = FindObjectOfType<updateHealth>();  
        StartCoroutine(EnergyRecoveryCoroutine());
    }

    void FixedUpdate() 
    {
        if(healthAmmo<=0)
        {
            END();
        }
        switch (levelOfHealthAmmo)
        {
        case 5:
            //print ("150 - 200");
            maxHealthAmmo = 200;
            break;
        case 4:
            //print ("100 - 150");
            maxHealthAmmo = 150;
            break;
        case 3:
            //print ("50 - 100");
            maxHealthAmmo = 100;
            break;
        case 2:
            //print ("25 - 50");
            maxHealthAmmo = 50;
            break;
        case 1:
            //print ("0 - 25");
            maxHealthAmmo = 25;
            break;
        default:
            //print ("Incorrect intelligence level.");
            break;
        }
        
        if(healthAmmo <= 25)
        {
            if(rangeOfHealthAmmo != 1){
                rangeOfHealthAmmo = 1;
                changeSize(20);
            }
        }
        else if(healthAmmo <= 50)
        {
            if(rangeOfHealthAmmo != 2){
                rangeOfHealthAmmo = 2;
                changeSize(35);
            }        
        }
        else if(healthAmmo <= 100)
        {
            if(rangeOfHealthAmmo != 3){
                rangeOfHealthAmmo = 3;
                changeSize(50);
            }

        }
        else if(healthAmmo <= 150)
        {
            if(rangeOfHealthAmmo != 4){
                rangeOfHealthAmmo = 4;
                changeSize(65);
            }
        }
        else if(healthAmmo <= 200)
        {
            if(rangeOfHealthAmmo != 5){
                rangeOfHealthAmmo = 5;
                changeSize(80);
            }
        }

        if(takeHit == true)
        {
            float hit = 10;
            lostHealth(hit);
        }

    }

    void changeSize(int range)
    {   
        Transform TP = triPlayer.transform;
        TP.localScale = new Vector3(range,range,range);

    }

    void END()
    {
        gameOver.SetActive(true);
        Destroy(gameObject);
    }

    // tiene que ser llamada por el daño probocado por el enemigo y mandar el damage con el huit collider
    void lostHealth(float damage)
    {
        if (healthAmmo <= 0 || (healthAmmo-damage) <= 0)
        {

            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            healthAmmo = healthAmmo - damage;
            healthSpendDateTime = System.DateTime.Now;
            updateText();
            takeHit = false;
        }

    }

    // se llama cada que pierdes una bala 
    public void lostBullets(float shotBullet)
    {
        if(healthAmmo <= 10)
        {
            Debug.Log("Ammo to low, please wait");
        }
        else
        {
            healthSpendDateTime = System.DateTime.Now;
        
            healthAmmo = healthAmmo - shotBullet;
            updateText();
        }

    }

    void updateText()
    {
        updateTXT.UpdateTextValue(healthAmmo, maxHealthAmmo);
    }

    void RecoverHealthAmmoTime()
    {
        timePassed = (float)(System.DateTime.Now - healthSpendDateTime).TotalSeconds;

        
        if(timePassed >= timeToRecoverHealthAmmo)
        {
            healthAmmo++;
            healthAmmo++;

            if (healthAmmo >= maxHealthAmmo)
            {
                healthAmmo = maxHealthAmmo;
            }
        }

    }

    public float getHealthAmmo()
    {
        return healthAmmo;
    }

    public void takeDamage(int hitDamage)
    {

        healthAmmo -= hitDamage;

    }

    IEnumerator EnergyRecoveryCoroutine()
    {
        while (true)
        {
            RecoverHealthAmmoTime();
            updateText();
            yield return new WaitForSeconds(1);
        }
    }
}

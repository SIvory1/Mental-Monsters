using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    //sets variables
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public bool shootBool;
    public float shootTimer;
    public float fireRate;

    //on start sets shootTimer = 0
    private void Start()
    {
        shootTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetButtonDown("Fire1"))
                shootBool = true;
            if (Input.GetButtonUp("Fire1"))
                shootBool = false;
        
      
     
        // this sets the value of shootTimer to the amount of seconds 
        // it took for the engine to process the previous frame
        shootTimer += Time.deltaTime;


        // this allows player to shoot, can set how fast bullets can spawn 
        if (shootBool && shootTimer > fireRate) {
            Shoot();
            shootTimer = 0;
        } 
            
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
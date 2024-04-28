using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADHDAttacks : MonoBehaviour
{
    //for bomb drop
    public Transform bombSpawnPoint;
    public GameObject bombPrefab;
    public float bombDropTimer;
    public float chargeAttackTime;

    //for bullet
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpawnRate;

    //player
    public float playerPositionTimer;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        bulletSpawnRate += Time.deltaTime;
        bombDropTimer += Time.deltaTime;
        //calls bomb function
        bombAttack();

        if (bulletSpawnRate > 3)
        {
            ADHDBullet();
            bulletSpawnRate = 0;
        }


        // gets ADHDAttacks
        GameObject ADHDdirection = GameObject.Find("Boss ADHD");
        BossADHD direction = ADHDdirection.GetComponent<BossADHD>();

        //when player stops moving, drops bomb but only when in follow 
        //player mode
        if (player.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.01f && direction.targetDirection == direction.playerDirection)
        {
            playerPositionTimer += Time.deltaTime;
            if (playerPositionTimer > 0.75f)
            {
                Bomb();
                playerPositionTimer = 0f;
            }
        }
        else { playerPositionTimer = 0f; }
        
    }

    void bombAttack()
    {
        GameObject bombScript = GameObject.Find("Boss ADHD");
        BossADHD bombDrop = bombScript.GetComponent<BossADHD>();
        //calls the ball spawn when timer is reached and when ADHD follows random flyer
        if (bombDropTimer > chargeAttackTime && bombDrop.bombAttackActive == true)
        {
            Bomb();
            //resets variables
            bombDropTimer = 0f;
            bombDrop.bombAttackActive = false;
        }
    }

   public void Bomb()
    {
        //spawns bomb
        Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
    }

    void ADHDBullet()
    {
        //spawns bullet
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}

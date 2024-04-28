using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADHDBullet : MonoBehaviour
{

    public int bulletSpeed;
    public float playerDirection;
    public float Directionplayer;
    public float bulletDuration;
    int bulletHealth = 3;


    public void Start()
    {
        GameObject sound = GameObject.Find("Audio Manager");
        AudioManager audio = sound.GetComponent<AudioManager>();
        audio.ProjectileSound();
    }


    void OnCollisionEnter2D(Collision2D theCollision)
    {
        // finds helath scirpt
        GameObject findHealth = GameObject.Find("The troll");
        Health healthBar = findHealth.GetComponent<Health>();
        // on colliosn wioth player destroys bullet and removes player health
        if (theCollision.gameObject.name == "The troll")
        {
            Destroy(gameObject);
            healthBar.TakeDamage(10);
            print(healthBar.health);
        }
        if (theCollision.gameObject.name == "Bullet(Clone)")
        {
            bulletHealth -= 1;
            BulletHealth();
        }
    }

    void Update()
    {
        bulletDuration += Time.deltaTime;

        if (bulletDuration > 4f)
          Destroy(gameObject);

        GameObject findPlayer = GameObject.Find("The troll");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerDirection, Directionplayer ).normalized * bulletSpeed;

        playerDirection = findPlayer.gameObject.transform.position.x - gameObject.transform.position.x;
        Directionplayer = findPlayer.gameObject.transform.position.y - gameObject.transform.position.y;
    }

    void BulletHealth()
    {
        if (bulletHealth == 0)
            Destroy(gameObject);
    }

}






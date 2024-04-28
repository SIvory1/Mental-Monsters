using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionProjectile : MonoBehaviour
{

    public float bulletspeed = 10f;
    Rigidbody2D rb;

    Transform target;
    Vector2 movedirection;

    void Start()
    {
        target = (GameObject.Find("The troll")).transform;
        rb = GetComponent<Rigidbody2D>();
        movedirection = (target.transform.position - transform.position).normalized * bulletspeed;
        rb.velocity = new Vector2(movedirection.x, movedirection.y);
        
        GameObject sound = GameObject.Find("Audio Manager");
        AudioManager audio = sound.GetComponent<AudioManager>();
        audio.ProjectileSound();

        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        // finds helath scirpt
        GameObject findHealth = GameObject.Find("The troll");
        Health healthBar = findHealth.GetComponent<Health>();
        // on colliosn with player destroys bullet and removes player health
        if (theCollision.gameObject.name == "The troll")
        {
            Destroy(gameObject);
            healthBar.TakeDamage(10);
            print(healthBar.health);
        }
        if (theCollision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}

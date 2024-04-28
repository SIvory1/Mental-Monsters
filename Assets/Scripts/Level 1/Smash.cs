using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    public float dropForce = 5f;
    public Rigidbody2D rb;

    public float fieldOfImpact;
    public int force;
    public LayerMask layerToHit;

    void Explode()
    {
        //explosion logic
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);

        foreach (Collider2D obj in objects)
        {
            //sets the direction
            Vector2 direction = new Vector2(obj.transform.position.x - transform.position.x, 0.1f);
            //makes the player get thrown 
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

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
            healthBar.TakeDamage(30);
            print(healthBar.health);
            Explode();

            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();
            audio.SlamSound();
        }
        if (theCollision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();
            audio.SlamSound();
        }
        
    }
}

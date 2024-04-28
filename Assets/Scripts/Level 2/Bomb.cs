using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float fieldOfImpact;
    public int force;
    public LayerMask layerToHit;
    public float timeToExplode;

    // for health
    public float explosionRange;


    void Update()
    {
        //finds the Player game object and extracts the health script
        GameObject theplayer = GameObject.Find("The troll");
        Health healthBar = theplayer.GetComponent <Health>();
        // takes the positon of he bomb away from the player
        explosionRange = theplayer.gameObject.transform.position.x - gameObject.transform.position.x;
        //timer
        timeToExplode += Time.deltaTime;

        if (timeToExplode > 2f)
        {
            // calls sound fucntion
            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();
            audio.BombSound();

            // everything for bomb to expode and disaopear
            Explode();
            Destroy(gameObject); 

            //if player is in range of blast then 
            if (explosionRange > -2.5f && explosionRange < 2.5f)
            {
                //take away health
               healthBar.TakeDamage(10);
               print(healthBar.health);
               
            }
        }
    }

    void Explode()
    {
        //explosion logic
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);

        foreach (Collider2D obj in objects)
        {

            Vector2 direction = new Vector2(obj.transform.position.x - transform.position.x, 0.1f);
            //makes the player get thrown 
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        
    }
   
    void OnDrawGizmosSelected()
    {
        //sets blast radious
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyWindAttackLeft : MonoBehaviour
{

    public Rigidbody2D rb;
    public LayerMask layerToHit;
    public GameObject thePlayer;
    public int force;
    public float forceTimer;

    void OnEnable()
    {
        force = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AirBlast();

        forceTimer += Time.deltaTime;

        if (forceTimer > 0.1f)
        {
            forceTimer = 0f;
            force += 1;
        }
    }

    void AirBlast()
    {
        //lazer logic
       Collider2D[] objects = Physics2D.OverlapBoxAll(transform.position, new Vector3(10, 12f, 1), layerToHit);

        foreach (Collider2D obj in objects)
        {
            if (obj.gameObject == thePlayer.gameObject)
            {
                rb.velocity = Vector2.right * force;
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        //shows lazer radious
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(10, 0.25f, 1));
    }
    
}
//sets the direction, this shit is confusing
//Vector2 direction = new Vector2(obj.transform.position.x - transform.position.x, 0f);
//makes the player get thrown 
//obj.GetComponent<Rigidbody2D>().AddForce(direction* force);
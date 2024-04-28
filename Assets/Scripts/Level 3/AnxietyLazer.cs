using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyLazer : MonoBehaviour
{
    public LayerMask layerToHit;
    public GameObject thePlayer;
    public GameObject platForm1;
    public GameObject platForm2;
    public GameObject platForm3;

    public bool touchingPlatform = false;


     void Start()
    {
        touchingPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        Lazer();
    }

    void Lazer()
    {

        //lazer logic
        Collider2D[] objects = Physics2D.OverlapBoxAll(transform.position, new Vector3(0.7f, 10, 1), layerToHit);

        foreach (Collider2D obj in objects)
        {
            // turns lazer off if collides with platform
            if (obj.gameObject == platForm1.gameObject || obj.gameObject == platForm2.gameObject || obj.gameObject == platForm3.gameObject)
            {
                touchingPlatform = true;
            }
            // if lazer is touching platform then cant harm player
            if (obj.gameObject == thePlayer.gameObject && touchingPlatform == false)
            {
                // removes health from player
                GameObject findHealth = GameObject.Find("The troll");
                Health healthBar = findHealth.GetComponent<Health>();
                healthBar.TakeDamage(0.3f);
                healthBar.slider.value = healthBar.health;
            }
        }
        touchingPlatform = false;
    }

 
    void OnDrawGizmosSelected()
    {
        //shows lazer radious
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.7f, 10, 1));
    }

}


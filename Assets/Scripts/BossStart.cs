using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour
{

    public GameObject pet;
    public GameObject boss;

    public void OnTriggerEnter2D(Collider2D theCollision)
    {
        // when player goes to far right the boss spawns 
        if (theCollision.gameObject.name == "The troll")
        {
            // spanws boss and despawns pet
            boss.gameObject.SetActive(true);
            pet.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}

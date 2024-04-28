using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyDroneLeft : MonoBehaviour
{

    public int health;
    public GameObject WindAttack;
    public float windAttackTimer;


    void OnEnable()
    {
        WindAttack.SetActive(false);
        windAttackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        windAttackTimer += Time.deltaTime;
        if (windAttackTimer > 3.5f)
        {
            WindAttack.SetActive(true);
            windAttackTimer = 0;
        }

        DroneDestroyed();
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }

    void DroneDestroyed()
    {
        if (health == 0)
        {
            gameObject.SetActive(false);
            WindAttack.SetActive(false);
            health = 5;
        } 
    
    }

}

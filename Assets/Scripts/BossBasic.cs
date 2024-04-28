using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossBasic : MonoBehaviour
{

    //boss movement variables
    public int bossSpeed = 10;
    public GameObject player;
    public GameObject flyer;
    private float targetDirection;
    private float playerDirection;
    private float randomDirection;
    public bool switchTarget;
    private float switchTimer;
    public float maxSwitchTimer;

    //Boss health
    public float bossHealth;
    public GameObject pet;

    // Update is called once per frame
    void Update()
    {

        // this is the timer that sets when the boss will switch targets
        switchTimer += Time.deltaTime;
        if (switchTimer > maxSwitchTimer)
        {
            switchTarget = !switchTarget;
            switchTimer = 0;
        }

        // finds player position
        playerDirection = player.gameObject.transform.position.x - gameObject.transform.position.x;

        if (switchTarget == true) 
        {
            //makes boss follow player
            targetDirection = playerDirection;
        }
        else
        {
            //makes boss stand still
            targetDirection = 0f;
        }

        
        //boss movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(targetDirection * bossSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        // this kills boss
        if (bossHealth <= 0)
        {
            //spawns in pet despawns boss
            gameObject.SetActive(false);
            pet.gameObject.SetActive(true);
        }

    }

    //removes health from boss when shot
    public void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Bullet")
        {
            bossHealth -= 1;
        }
    }
}

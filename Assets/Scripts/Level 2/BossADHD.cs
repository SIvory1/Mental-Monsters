using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossADHD : MonoBehaviour
{
    
     //boss movement variables
    public int bossSpeed = 10;
    public GameObject player;
    public GameObject flyer;
    public float targetDirection;
    public float playerDirection;
    public float randomDirection;
    public bool flipTarget;
    private float flipTimer;
    public float maxFlipTimer;

    //Boss health
    public float bossHealth;
    public GameObject pet;
    public Slider ADHDslider;
    public Text text;


    //Boss attacks
    public bool bombAttackActive = false;

    //finds the Player game object and extracts the health script
    void Start()
    {
        //makes the player respawn in the right level
        GameObject theplayer = GameObject.Find("The troll");
        Health healthBar = theplayer.GetComponent<Health>();
        healthBar.Level2 = true;
        SetMaxHealth();


        // for music
        GameObject sound = GameObject.Find("Audio Manager");
        AudioManager audio = sound.GetComponent<AudioManager>();
        audio.bossMusic.volume = 0.034f;
        audio.BossMusic();
        audio.GrowlTwo();

        ADHDslider.gameObject.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        // this is the timer that sets when the boss will switch targets
        flipTimer += Time.deltaTime;
        if (flipTimer > maxFlipTimer)
        {
            flipTarget = !flipTarget;
            flipTimer = 0;
        }

        // finds player position
        playerDirection = player.gameObject.transform.position.x - gameObject.transform.position.x;
        // finds random flyers position
        randomDirection = flyer.gameObject.transform.position.x - gameObject.transform.position.x;


        if (flipTarget == true)
        {
            //follows player
            targetDirection = playerDirection;
        }
        else
        {
            // follows random flyers and uses bomb attack
            bombAttackActive = true;
            targetDirection = randomDirection;
        }
        
        //boss movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(targetDirection * bossSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
      
        // calls kill boss function   
        BossDeath();

        if (bossHealth == 30)
        {
            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();
            audio.GrowlTwo();
        }
    }

    public void SetMaxHealth()
    {
        //sets the boss health to the slider
        ADHDslider.maxValue = bossHealth;
        ADHDslider.value = bossHealth;
    }

    //makes boss lose health
    public void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Bullet")
        {
            bossHealth -= 1;
            //removes health from healthbar
            ADHDslider.value = bossHealth;
        }
    }

    void BossDeath()
        {
        if (bossHealth <= 0)
        {
            gameObject.SetActive(false);
            pet.gameObject.SetActive(true);
            text.gameObject.SetActive(true);

            // on death audio
            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();

            audio.DeathSound();
            audio.musicStop = true;
        }
    }
}


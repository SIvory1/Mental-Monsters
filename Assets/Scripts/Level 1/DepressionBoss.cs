using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DepressionBoss : MonoBehaviour
{

    //boss movement variables
    public int bossSpeed = 10;
    public GameObject player;
    public float targetDirection;
    public float playerDirection;

    //Boss health
    public float bossHealth;
    public GameObject pet;
    public GameObject boss;
    public Slider DepressionSlider;
    public Text text;


    //Boss attacks
    public bool chargedAttack = false;

    //finds the Player game object and extracts the health script
    void Start()
    {
        //rb = GetComponent<Rigidbody2D> ();

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
        audio.GrowlThree();

        DepressionSlider.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        // finds player position
        playerDirection = player.gameObject.transform.position.x - gameObject.transform.position.x;
        targetDirection = playerDirection;

        //boss movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(targetDirection * bossSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        //Is boss enraged
        Enraged();

        // calls kill boss function   
        BossDeath();

        if (bossHealth == 30)
        {
            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();
            audio.GrowlThree();
        }
    }

    public void SetMaxHealth()
    {
        //sets the boss health to the slider
        DepressionSlider.maxValue = bossHealth;
        DepressionSlider.value = bossHealth;
    }

    //makes boss lose health
    public void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Bullet")
        {
            bossHealth -= 1;
            //removes health from healthbar
            DepressionSlider.value = bossHealth;
        }
    }

    void Enraged()
    {
        if (bossHealth <= 40)
        {
            chargedAttack = true;
        }
    }

    void BossDeath()
    {
        if (bossHealth <= 0)
        {
            boss.SetActive(false);
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

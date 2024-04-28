using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAnxiety : MonoBehaviour
{

    public float speed;
    public float bossHealth;
    public float turnPositionRandomised;
    public float turnPositionFix;

    public Slider Anxietyslider;
    public GameObject pet;
    public Text text;

    void Start()
    {
        //gives the boss a start point to reach 
         turnPositionRandomised = Random.Range(-6f, 22.7f);
       
          //makes the player respaqn in the right level
        GameObject theplayer = GameObject.Find("The troll");
        Health healthBar = theplayer.GetComponent<Health>();
        healthBar.Level3 = true;
        SetMaxHealth();

        // sets music
        GameObject sound = GameObject.Find("Audio Manager");
        AudioManager audio = sound.GetComponent<AudioManager>();
        audio.bossMusic.volume = 0.034f;
        audio.BossMusic();
        audio.GrowlOne();


        Anxietyslider.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
   
        // calls kill boss fucntion   
        BossDeath();

        // sets movenment
        MovementConditions();

        turnPositionFix += Time.deltaTime;

        // if the boss hasnt reached its goal in 10 secs
        // it finds a new point. this is to fix a weird
        // bug where the movement glitches
        if (turnPositionFix > 10f)
        {
            turnPositionRandomised = Random.Range(-6f, 21.2f);
            turnPositionFix = 0f;
        }

        // play boss growl
        if (bossHealth < 30)
        {
            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();
            audio.GrowlOne();
        }
    }

    void FlipBoss()
    {
        //flips 180degrees
        transform.Rotate(0f, 180f, 0f);
    }

    public void SetMaxHealth()
    {
        //sets the boss health to the slider
        Anxietyslider.maxValue = bossHealth;
        Anxietyslider.value = bossHealth;
    }

    public void OnCollisionEnter2D(Collision2D theCollision)
    {
        //makes the boss take damage
        if (theCollision.gameObject.tag == "Bullet")
        {
            bossHealth -= 1;
            //removes health from healthbar
            Anxietyslider.value = bossHealth;
        }
        if (theCollision.gameObject.name == "Wall 1")
         FlipBoss(); 
        else if (theCollision.gameObject.name == "Wall 2")
         FlipBoss(); 
    }

    void MovementConditions()
    {
       // when the boss reaches its location it flips
       // and gets new location
        if (this.transform.localPosition.x > turnPositionRandomised)
        {
            FlipBoss();
            turnPositionRandomised = Random.Range(-6f, 21.2f);
            turnPositionFix = 0;
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

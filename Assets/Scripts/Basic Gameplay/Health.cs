using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100;
    public bool Level1 = false;
    public bool Level2 = false;
    public bool Level3 = false;

    //healthbar
    public Slider slider;
    public Animator animator;

    public AudioSource damageSound;

    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //when the player dies, they restart the level
        //will need to make a bool for each one
        //in boss ADHD script it makes the bool true when
        //start function is called
        if (health <= 0 && Level1)
        {
            SceneManager.LoadScene("Level 1");
            health = 100;
        }

        if (health <= 0 && Level2)
        {
            SceneManager.LoadScene("Level 2");
            health = 100;
        }

        if (health <= 0 && Level3)
        {
            SceneManager.LoadScene("Level 3");
            health = 100;
        }
    }

    // makes the slider match the health
    public void SetMaxHealth()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //call this when player takes 10 damage 
    public void TakeDamage(float x)
    {
        damageSound.Play();
        health -= x;
        slider.value = health;
        animator.SetTrigger("HasDamageTrigger");
    }
}

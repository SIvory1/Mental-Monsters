﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    public float speed = 20f;
    public Rigidbody2D rb;
    public AudioSource bulletSound;


   void Start()
    {
        // determines speed of ball 
        rb.velocity = transform.right * speed;
        bulletSound.Play();
    }

   
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        // on collison bullet object is destroyed
        Destroy(gameObject);
    }

}

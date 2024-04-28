using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource Growl1;
    public AudioSource Growl2;
    public AudioSource Growl3;
    public AudioSource bombSound;
    public AudioSource deathSound;
    public AudioSource lazerSound;
    public AudioSource projectileSound;
    public AudioSource slamSound;
    public AudioSource bossMusic;

    public bool musicStop;
    public float musicStopTimer;


    public void Update()
    {
          if (musicStop == true)
          {
              MusicStop();
          }
    }




    public void GrowlOne()
    {
        Growl1.Play();
    }

    public void GrowlTwo()
    {
        Growl2.Play();
    }

    public void GrowlThree()
    {
        Growl3.Play();
    }

    public void BombSound()
    {
        bombSound.Play();
    }

    public void DeathSound()
    {
        deathSound.Play();
    }

    public void LazerSound()
    {
        lazerSound.Play();
    }

    public void ProjectileSound()
    {
        projectileSound.Play();
    }

    public void SlamSound()
    {
        slamSound.Play();
    }

    public void BossMusic()
    {
        bossMusic.Play();
    }

    
     public void MusicStop()
     {
       bossMusic.volume -= 0.00005f;
     }

}


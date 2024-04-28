using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawns : MonoBehaviour
{

    public GameObject platForm1;
    public GameObject platForm2;
    public GameObject platForm3;

    public int platformChosen;
    public float platformChooseTimer;
    public float platformChooseMaxTime;

    public bool platForm1True;
    public bool platForm3True;

    public GameObject pet;
    public int leftFlipCounter;
    public int rightFlipCounter;


    public bool platformSwitchLazerOff;
    public float platformSwitchLazerOffTimer;
    public GameObject lazer;


    public void Start()
    {
        StartPlatform();
        platformSwitchLazerOff = false;
    }


    // Update is called once per frame
    void Update()
    {
        // used to turn off lazer for short time
        // when switching platform
        if (platformSwitchLazerOff == true)
        {
            platformSwitchLazerOffTimer += Time.deltaTime;
            lazer.SetActive(false);
            GameObject sound = GameObject.Find("Audio Manager");
            AudioManager audio = sound.GetComponent<AudioManager>();
            audio.LazerSound();

            if (platformSwitchLazerOffTimer > 2.5f)
            {
                platformSwitchLazerOffTimer = 0f;
                lazer.SetActive(true);
                platformSwitchLazerOff = false;
                audio.LazerSound();
            }
        }


        platformChooseTimer += Time.deltaTime;

        // when timwe is reached platform switches
        if (platformChooseTimer > platformChooseMaxTime)
        {
            RandomisePlatform();
            platformChooseTimer = 0;
            // for turning off lazer
            platformSwitchLazerOff = true;
        }
    }

    void RandomisePlatform()
    {

        //picks number between 1 and 3
        platformChosen = Random.Range(1, 4);

        // sets platform to a number, if number is chosen
        // disables all platforms but the one chosen
        if (platformChosen == 1)
        {
            platForm1.SetActive(true);
            platForm2.SetActive(false);
            platForm3.SetActive(false);

            platForm1True = true;
            platForm3True = false;

            platformChooseMaxTime = 10;

            //for flipping sprite to show which platform is on
            leftFlipCounter += 1;
            rightFlipCounter = 0;
            //pet would flip again if platform repated itself due to it being 
            //random, this makes it so it can only flip once
            if (leftFlipCounter < 2)
            {
                pet.transform.Rotate(0f, 180f, 0f);
            }
        }

        if (platformChosen == 2)
        {
            platForm1.SetActive(false);
            platForm2.SetActive(true);
            platForm3.SetActive(false);

            platformChooseMaxTime = 5;

        }
        
        if (platformChosen == 3)
        {
            platForm1.SetActive(false);
            platForm2.SetActive(false);
            platForm3.SetActive(true);

            platForm1True = false;
            platForm3True = true;

            platformChooseMaxTime = 10;

            //for flipping sprite to show which platform is on
            rightFlipCounter += 1;
            leftFlipCounter = 0;
            //pet would flip again if platform repated itself due to it being 
            //random, this makes it so it can only flip once
            if (rightFlipCounter < 2)
            {
                pet.transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    // first platform thats active so that the flipping
    // pet works correctly
    void StartPlatform()
    {
        platForm1.SetActive(true);
        platForm2.SetActive(false);
        platForm3.SetActive(false);

        leftFlipCounter += 1;

        pet.transform.Rotate(0f, 180f, 0f);
    }    
}

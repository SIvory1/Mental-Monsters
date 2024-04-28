using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyAttacks : MonoBehaviour
{

    //Lazer variables
    public GameObject lazer;
    public float lazerStartTimer;
    public bool lazerStartBool;
    public float lazerEndTimer;
    public bool lazerEndBool = false;
    public float lazerStartFinish;
    public float lazerEndFinish;
    public bool hasRunOnce;

    //drone
    public GameObject DroneLeft;
    public GameObject DroneRight;

    public GameObject pet;

    void Start()
    {
        lazerStartBool = true;
    }


    // Update is called once per frame
    void Update()
    {

        GameObject platform = GameObject.Find("Platform");
        PlatformSpawns platformBool = platform.GetComponent<PlatformSpawns>();

        if (platformBool.platForm1True == true)
        {
            DroneLeft.SetActive(true);
            platformBool.platForm1True = false;
        }

        if (platformBool.platForm3True == true)
        {
            DroneRight.SetActive(true);
            platformBool.platForm3True = false;
        }



        if (lazerStartBool)
        {
            lazerStartTimer += Time.deltaTime;
            hasRunOnce = false;
        }


        if (lazerStartTimer > lazerStartFinish)
        {
            if (hasRunOnce == false)
            {
                AnxiousStartFunction();
            }
        }

        if (lazerEndBool)
        {
            lazerEndTimer += Time.deltaTime;
            hasRunOnce = false;
        }

        if (lazerEndTimer > lazerEndFinish)
        {
            if (hasRunOnce == false)
            {
                AnxiousEndFunction();
            }
        }




        /*

             }
                // this function shoots lazer
                public void LazerStartFunction()
                {
                    GameObject theplayer = GameObject.Find("The troll");
                    Movement anxious = theplayer.GetComponent<Movement>();
                    // affects player movement
                 //   anxious.isAnxious = true;
                    // changes bools so it runs lazerEndFunction
                    lazerStartBool = false;
                    lazerEndBool = true;
                    // resets timer
                    lazerStartTimer = 0f;
                    // activates lazer
                    lazer.gameObject.SetActive(true);
                    // activates bool so Lazerfunctions only run once per loop
                    hasRunOnce = true;
                    print("start");
                }

                    // this deactivates lazer
                public void LazerEndFunction()
                {
                    GameObject theplayer = GameObject.Find("The troll");
                    Movement anxious = theplayer.GetComponent<Movement>();
                    // affects player movement
                  //  anxious.isAnxious = false;
                    // changes bools so it runs lazerStartFunction
                    lazerStartBool = true;
                    lazerEndBool = false;
                    // resets timer
                    lazerEndTimer = 0f;
                    // deactivates lazer
                    lazer.gameObject.SetActive(false);
                    // activates bool so Lazerfunctions only run once per loop
                    hasRunOnce = true;
                    print("end");
                }

             */
    }


     public void AnxiousStartFunction()
     {
        //calls movement script to invert controls
        GameObject theplayer = GameObject.Find("The troll");
        Movement player = theplayer.GetComponent<Movement>();
        player.isAnxious = true;

        lazerStartBool = false;
        lazerEndBool = true;
        lazerStartTimer = 0f;
    
        // activates bool so Lazerfunctions only run once per loop
        hasRunOnce = true;

        // turns pet upside down to signal that controls are inverted
        pet.transform.Rotate(180f, 0f, 0f);
    }

    public void AnxiousEndFunction()
    {
        //calls movement script to put controls back to normal
        GameObject theplayer = GameObject.Find("The troll");
        Movement player = theplayer.GetComponent<Movement>();
        player.isAnxious = false;

        lazerStartBool = true;
        lazerEndBool = false;
        lazerEndTimer = 0f;
        // activates bool so Lazerfunctions only run once per loop
        hasRunOnce = true;
   
        // turns pet right side up to show no longer inverted 
        pet.transform.Rotate(180f, 0f, 0f);
    }
}
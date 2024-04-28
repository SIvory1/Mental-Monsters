using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float speed;
    public bool isPlatformUp = true;
    public float platformTimer;

    void Start()
    {
       isPlatformUp = true;
    }

    // Update is called once per frame
    void Update()
    {

        platformTimer += Time.deltaTime;

        // when platfrom below certain height
        if (transform.localPosition.y < -3f && isPlatformUp == true)
        {
            // it goes up
            platformUp();
        }
        else
        {
            isPlatformUp = false;
        }

        // when reaches certain height
        if (isPlatformUp == false)
        {
            // it goes down
            platformDown();
        }
    }

    // when it hits the ground, it stops for a second then goes up
    public IEnumerator OnCollisionEnter2D(Collision2D theCollision)
    {
    if (theCollision.gameObject.tag == "Ground")
        {
            speed = 0f;
            yield return new WaitForSeconds(1f);
            isPlatformUp = true;
        }
    }
    // platfrom goes upward code
    void platformUp()
    {
        speed = 1f;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

   // platfrom goes downward code
    void platformDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

}

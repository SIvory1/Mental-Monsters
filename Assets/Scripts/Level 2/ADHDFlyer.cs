using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADHDFlyer : MonoBehaviour
{

    public int bossSpeed = 10;
    public float Direction;
    public bool facingRight = false;


    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Direction, 0) * bossSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall 1" || collision.gameObject.name == "Wall 2")
        {
            FlipFlyer();
        }
    }

    void FlipFlyer()
    {
        if (Direction > 0)
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
    }
}

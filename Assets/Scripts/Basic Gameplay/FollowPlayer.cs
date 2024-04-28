using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform objectToFollow;
    public Vector3 offset;

    // This makes the pet follow the player, can adjust who to follow and the offset between player and pet in inspector
    void Update()
    {
        transform.position = objectToFollow.position + offset;
    }
}



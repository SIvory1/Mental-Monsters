using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // this finds the player when the game starts
    void Start () {
        player = GameObject.FindWithTag ("Player");
    }
	
	// Update is called once per frame, makes the camera follow the player
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}

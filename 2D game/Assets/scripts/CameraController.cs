using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public GameObject player;
    public float offset;
    private Vector3 playerPosition;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //player x position    //y, z positions of the camera
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        
        //player turning right
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        //player turning left
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset / 2, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject regular_Platform;
    public GameObject spike_Platform;
    public GameObject[] moving_Platforms;
    public GameObject breakable_Platform;

    public float platform_Spawn_Timer = 2f;

    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;

    public float min_X = -2.15f, max_X = 2.15f;

    // Start is called before the first frame update
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }


    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;

        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            //to control the spawning queue
            platform_Spawn_Count++;

            Vector3 temp = transform.position;
            // Assign a horizontal position of platform within screen limits
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            if (platform_Spawn_Count < 2)
            {
                //if less than 2 platforms spawn a regular platform
                newPlatform = Instantiate(regular_Platform, temp, Quaternion.identity);
            }
            else if (platform_Spawn_Count == 2)
            {
                //Random.Range(0, 2) will return an integer value 0 or 1
                if (Random.Range(0, 2) > 0)
                {
                    //spawn a regular platform
                    newPlatform = Instantiate(regular_Platform, temp, Quaternion.identity);
                }
                else
                {   //spawn new random moving platform Left or Right 
                    newPlatform = Instantiate(moving_Platforms[Random.Range(0, moving_Platforms.Length)], temp, Quaternion.identity);

                }
            }
            else if (platform_Spawn_Count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    //spawn a regular platform
                    newPlatform = Instantiate(regular_Platform, temp, Quaternion.identity);
                }
                else
                {   //spawn new platform of spike type
                    newPlatform = Instantiate(spike_Platform, temp, Quaternion.identity);

                }
            }
            else if (platform_Spawn_Count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    //spawn a regular platform
                    newPlatform = Instantiate(regular_Platform, temp, Quaternion.identity);
                }
                else
                {   //spawn new platform of breakable type
                    newPlatform = Instantiate(breakable_Platform, temp, Quaternion.identity);

                }

                //to reset and go back through all iterations 
                platform_Spawn_Count = 0;
            }
         
            if (newPlatform)
            {
                //every new platform that's gonna be spawned will be a child of the platform spawner
                newPlatform.transform.parent = transform;
            }

            //reset spawn timer
            current_Platform_Spawn_Timer = 0f;

        }

    } //spawn platforms

} //class

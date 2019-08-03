using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public GameObject MenuVals;

    private int platform_Spawn_Count;
    private int counter = 0;
    private int num;

    public float min_X = -2f, max_X = 2f;
    
    // Update is called once per frame
    void Update()
    {
        if (!MenuVals.GetComponentInChildren<PauseMenu>().GameIsPaused && !MenuVals.GetComponentInChildren<PauseMenu>().MainMenuUp)
        {
            counter++;
            if (counter % 40 == 0)
            {
                SpawnPlatforms();
            }
            if (counter > 100000) counter = 0;
        }
    }

    void SpawnPlatforms()
    {
        platform_Spawn_Count++;
        Vector3 temp = transform.position;
        temp.x = Random.Range(min_X, max_X);

        GameObject newPlatform = null;

        if(platform_Spawn_Count < 2)
        {
            newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
        }
        else if(platform_Spawn_Count == 2)
        {
            if (Random.Range(0,2) > 0)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], 
                    temp, Quaternion.identity);
            }
        }
        else if(platform_Spawn_Count == 3)
        {
            if (Random.Range(0, 5) > 3)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
            }
        }

        else if (platform_Spawn_Count == 4)
        {
            if (Random.Range(0, 2) > 0)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else
            {
                newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
            }

            platform_Spawn_Count = 0;
        }
        if (newPlatform)
        {
            newPlatform.transform.parent = transform;
        }
    }
}

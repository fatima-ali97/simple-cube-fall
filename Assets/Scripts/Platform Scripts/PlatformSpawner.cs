using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{


    public GameObject platformPrefab; 
    public GameObject SpikePlatformPrefab; 
    public GameObject[] movingplatforms;
    public GameObject BreakablePlatform;


    public float platformSpawnerTimer = 2f;
    private float current_Platform_Spawn_Timer;

    private int platform_spawner_Count;


    public float min_x= -2f , max_x= 2f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_Platform_Spawn_Timer = platformSpawnerTimer; 
    }

    // Update is called once per frame
    void Update()
    {
        spawnPlatforms();
    }

    void spawnPlatforms()
    {

        current_Platform_Spawn_Timer += Time.deltaTime;

        if (current_Platform_Spawn_Timer >= platformSpawnerTimer) { 
            platform_spawner_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_x, max_x);

            GameObject newPlatform = null;

            if(platform_spawner_Count < 2) {

                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

            } else if(platform_spawner_Count == 2) { 

                if(Random.Range(0, 2) > 0) {

                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                } else {

                    newPlatform = Instantiate(
                        movingplatforms[Random.Range(0, movingplatforms.Length)],
                        temp, Quaternion.identity);

                }

            } else if(platform_spawner_Count == 3) {

                if (Random.Range(0, 2) > 0) {

                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                } else {

                    newPlatform = Instantiate(BreakablePlatform, temp, Quaternion.identity);

                }

            } else if (platform_spawner_Count == 4) {

                if (Random.Range(0, 2) > 0) {

                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                } else {

                    newPlatform = Instantiate(BreakablePlatform, temp, Quaternion.identity);

                }

                platform_spawner_Count = 0;

            }

            if(newPlatform)
                newPlatform.transform.parent = transform;

            current_Platform_Spawn_Timer = 0f;
        }

    }
}

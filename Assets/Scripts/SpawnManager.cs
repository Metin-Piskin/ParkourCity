using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObstacleSpawn;
    private Vector3 SpawnPosition = new Vector3(23,0,0);
    private float StartTime = 2f;
    private float RepetitionTime = 3f;
    private PlayerController PlayerControllerScript;

    void Start()
    {
        InvokeRepeating("CreateObstacles", StartTime, RepetitionTime);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateObstacles()
    {
        if (PlayerControllerScript.GameOver == false)
        {
            int ObstacleIndex = Random.Range(0, ObstacleSpawn.Length);
            Instantiate(ObstacleSpawn[ObstacleIndex], SpawnPosition, ObstacleSpawn[ObstacleIndex].transform.rotation);
        }
    }
}

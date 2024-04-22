using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float Speed = 15f;
    private PlayerController PlayerControllerScript;
    private float ObstacleLimit = -9; 

    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (PlayerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (transform.position.x < ObstacleLimit && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

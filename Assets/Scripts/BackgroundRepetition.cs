using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepetition : MonoBehaviour
{
    private Vector3 StartPos;
    private float RepetitionSiz;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        RepetitionSiz = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < StartPos.x - RepetitionSiz)
        {
            transform.position = StartPos;
        }
    }
}

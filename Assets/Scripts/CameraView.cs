using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    Transform playerPos;
    Vector3 cameraPos;

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        cameraPos = transform.position;
        cameraPos.x = playerPos.position.x + 10f;
       // cameraPos.y = playerPos.position.y + 9f;
        transform.position = cameraPos;
    }
}

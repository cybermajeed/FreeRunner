using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [SerializeField] private GameObject[] groundToGenerate;
    private GameObject groundTrack, groundRocks, groundSlanted;
    private float lastPos = 68.8f;
    private float playerPos;

    void Start()
    {
        groundSlanted = groundToGenerate[0];
        groundRocks = groundToGenerate[1];
        groundTrack = groundToGenerate[2];
    }

    void FixedUpdate()
    {
        StartCoroutine(GenerateGround());
    }

    IEnumerator GenerateGround()
    {
        playerPos = lastPos - GameObject.FindWithTag("Player").transform.position.x;
        if (playerPos <= 100)
        {
            Instantiate(groundSlanted, new Vector3(lastPos, 6f, 35f), Quaternion.Euler(-40f, 0f, 0f));

            Instantiate(groundRocks, new Vector3(lastPos, 0f, 18f), Quaternion.identity);

            Instantiate(groundTrack, new Vector3(lastPos, 0f, -1.8f), Quaternion.identity);

            lastPos += 17.2f;
            yield return new WaitForSeconds(1f);
        }
    }
}
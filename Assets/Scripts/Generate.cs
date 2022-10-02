using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [SerializeField] private GameObject[] groundToGenerate;
    [SerializeField] private GameObject[] groundToGenRocks;
    private GameObject groundTrack, groundSlanted, groundRocks;
    private float lastPos = 68.8f;
    private float playerPos;
    int randRange;

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
            randRange = Random.Range(0, 7);
            Instantiate(groundToGenRocks[randRange], new Vector3(lastPos, -1f, 18f), Quaternion.Euler(0f, Random.Range(0, 360), 0f));

            Instantiate(groundRocks, new Vector3(lastPos, 0f, 18f), Quaternion.identity);

            Instantiate(groundTrack, new Vector3(lastPos, 0, -1.8f), Quaternion.identity);

            Instantiate(groundSlanted, new Vector3(lastPos, 6f, 35f), Quaternion.Euler(-40f, 0f, 0f));

            lastPos += 17.2f;
            yield return new WaitForSeconds(1f);
        }
    }
}
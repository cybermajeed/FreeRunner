using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [SerializeField] private GameObject[] groundToGenerate;
    float lastPos = 68.8f;
    float playerPos;
    void FixedUpdate()
    {
            StartCoroutine(GenerateGround());
    }

    IEnumerator GenerateGround()
    {
        playerPos = lastPos - GameObject.FindWithTag("Player").transform.position.x;
        if (playerPos <= 100)
        {
        Instantiate(groundToGenerate[Random.Range(0, 3)], new Vector3(lastPos, 0f, 0f), Quaternion.identity);
        lastPos += 17.2f;
        yield return new WaitForSeconds(1f);
        }
    }
}
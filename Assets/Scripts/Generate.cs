using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{

    bool create = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!create)
        {
            create = true;
            StartCoroutine(GenerateGround());
        }
    }

    IEnumerator GenerateGround()
    {
        yield return new WaitForSeconds(2);
        create = false;
    }
}

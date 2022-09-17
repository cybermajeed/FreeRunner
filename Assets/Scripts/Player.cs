using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    bool Landed = true;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //run 
        transform.Translate(Vector3.right * Time.deltaTime * Speed, Space.World);
        //jump
        bool jumpKey = (Landed) && 
            (Input.GetKey(KeyCode.Space) || 
            Input.GetKey(KeyCode.UpArrow));

        if (jumpKey)
        {
            rb.AddForce(new Vector3(0f, 33f, 0f), ForceMode.Impulse);
            Landed = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
            Landed = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
        }
    }
}

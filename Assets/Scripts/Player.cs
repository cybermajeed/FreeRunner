using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 25f;
    bool Landed = true;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 playerPos = transform.position;
        float Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal != 0)
        {
            playerPos.x += Horizontal * Time.deltaTime * Speed;
            transform.position = playerPos;

        }

        bool jumpKey = (Landed) && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
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

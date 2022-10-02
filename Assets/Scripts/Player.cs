using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 25f;
    bool Landed = true;
    Rigidbody rb;
    Animator anime;
    bool gameStarted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
    }
    private void Update()
    {
        //run 
        if (Input.GetKey(KeyCode.Space) && !gameStarted)
        {
            anime.SetBool("Running", true);
            transform.Translate(Time.deltaTime * Vector3.right, Space.World);
            StartCoroutine(GameStarted());
        }
        //jump
        bool jumpKey = (Landed) && (gameStarted) &&
            (Input.GetKey(KeyCode.Space) ||
            Input.GetKey(KeyCode.UpArrow));

        if (jumpKey)
        {
            rb.AddForce(new Vector3(0f, 33f, 0f), ForceMode.Impulse);
            Landed = false;
        }
    }

    IEnumerator GameStarted()
    {
        yield return new WaitForSeconds(.5f);
        gameStarted = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Landed = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
        }
    }
}

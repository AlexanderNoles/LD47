using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;

    public float speed = 10;
    public float jumpHeight = 5;
    public float platformDelay;
    private float h;
    private float v;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlatforms;
    private LayerMask finalmask;
    public bool groundedLastFrame;

    [Header("Audio")]
    public AudioSource jumpAudio;
    public AudioSource landAudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        finalmask = whatIsGround | whatIsPlatforms;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (h == -1)
        {
            sp.flipX = true;
        }
        else if (h == 1)
        {
            sp.flipX = false;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded())
        {
            rb.velocity = Vector2.up * jumpHeight;
            jumpAudio.Play();
        }

        //Platforms
        if (v == -1 && grounded())
        {
            gameObject.layer = 11;
            platformDelay = 0.5f;
        }

        if (platformDelay <= 0)
        {
            gameObject.layer = 10;
        }
        else
        {
            platformDelay -= Time.deltaTime;
            Debug.Log(platformDelay);
        }

        if (groundedLastFrame != grounded())
        {
            landAudio.Play();
        }

        groundedLastFrame = grounded();
    }

    private void FixedUpdate()
    {
        if (!PlayerManagment.wonLevel)
        {
            rb.velocity = new Vector3(h * speed, rb.velocity.y);
        }

        else
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }

    bool grounded()
    {
        return Physics2D.OverlapBox(transform.position - new Vector3(0, 0.56f), new Vector2(0.9f, 0.1f), 0f, finalmask);
    }
}

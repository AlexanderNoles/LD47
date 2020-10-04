using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public GameObject circle;
    private Animator ani;
    private float constant = 30;
    private float Scale = 0;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool("open", Physics2D.OverlapBox(transform.position, new Vector2(5, 5), 0f, whatIsPlayer));
        if (PlayerManagment.wonLevel)
        {
            circle.transform.localScale = new Vector3(Scale,Scale);
            Scale += constant * Time.deltaTime;
        }
    }
}

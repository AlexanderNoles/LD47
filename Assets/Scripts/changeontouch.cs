using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeontouch : MonoBehaviour
{
    public GameObject enabel;

    // Start is called before the first frame update
    void Start()
    {
        enabel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enabel.SetActive(true);
        }
    }
}

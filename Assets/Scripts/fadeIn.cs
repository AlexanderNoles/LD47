using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    private float alpha = 0;
    public Text text;
    public GameObject circle;

    private void Start()
    {
        text.color = new Color(0.1960f, 0.1960f, 0.1960f, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManagment.wonLevel)
        {
            text.color = new Color (0.1960f, 0.1960f, 0.1960f,alpha);
            alpha += Time.deltaTime;
        }
    }
}

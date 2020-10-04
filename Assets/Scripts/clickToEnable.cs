using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToEnable : MonoBehaviour
{
    public GameObject toEnable;
    public GameObject toDisable;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            toEnable.SetActive(true);
            toDisable.SetActive(false);
        }
    }
}

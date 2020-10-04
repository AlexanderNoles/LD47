using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    private float minusFromScale;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(100 - minusFromScale,100-minusFromScale);
        minusFromScale += 90 * Time.deltaTime;
        if (minusFromScale >= 100)
        {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagment : MonoBehaviour
{
    public GameObject circle;
    public GameObject circleMask;
    public GameObject player;
    public float levelDifficulty;
    public bool playerKilled;
    private float constant = 20;
    private float minusFromScale;

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManagment.wonLevel)
        {
            circleMask.transform.localScale = new Vector3(Mathf.Clamp(circle.transform.localScale.x - minusFromScale, 0, 1000), Mathf.Clamp(circle.transform.localScale.y - minusFromScale, 0, 1000), 0);
        }

        minusFromScale += levelDifficulty * constant * Time.deltaTime;

        circle.transform.position = player.transform.position;

        if (circle.transform.localScale.x <= minusFromScale && !PlayerManagment.wonLevel && circle.activeInHierarchy && !playerKilled)
        {
            PlayerManagment.deadPosList.Add(player.transform.position);
            playerKilled = true;           
            //Debug.Log("lmao, your code's fucked");
        }
    }
}

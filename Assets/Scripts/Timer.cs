using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool countDown = true;
    public string custom;
    public Text text;
    public LevelManagment lm;
    private int fullTime;
    private int time;

    private void Awake()
    {
        fullTime = Mathf.RoundToInt(5 / lm.levelDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown && !PlayerManagment.wonLevel)
        {         

            if(time >= 10)
            {
                text.text = "00:" + (time);
            }
            else
            {
                text.text = "00:0" + (time);
            }

            time = fullTime - Mathf.RoundToInt(Time.timeSinceLevelLoad);

        }

        else if (PlayerManagment.wonLevel)
        {

        }

        else
        {
            text.text = custom;
        }
    }
}

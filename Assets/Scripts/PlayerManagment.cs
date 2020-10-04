using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagment : MonoBehaviour
{
    public static bool wonLevel;
    public GameObject transitionCircle;
    private int nextLevel;
    public LevelManagment lm;
    public static List<Vector3> deadPosList = new List<Vector3>();

    private void Awake()
    {
        wonLevel = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ExitDoor") && !lm.playerKilled)
        {
            wonLevel = true;
            deadPosList = new List<Vector3>();
            nextLevel = col.gameObject.GetComponent<StoreNextLevel>().next_level;
            StartCoroutine("load");
        }

        if (col.CompareTag("ExitDoorAlt") && !lm.playerKilled)
        {
            wonLevel = true;
        }

        else if (col.CompareTag("KillBox"))
        {
            wonLevel = true;
            transitionCircle.transform.position = transform.position;
            StartCoroutine("hitbox");
        }
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextLevel);
    }

    IEnumerator hitbox()
    {
        yield return new WaitForSeconds(2);
        lm.playerKilled = true;
    }

    private void Update()
    {
        if (lm.playerKilled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            wonLevel = true;
            transitionCircle.transform.position = transform.position;
            deadPosList = new List<Vector3>();
            StartCoroutine("hitbox");
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeadPlayers : MonoBehaviour
{
    public GameObject prefab;
    private int i;

    private void Update()
    {
        if (PlayerManagment.deadPosList.Count > i)
        {
            transform.position = (PlayerManagment.deadPosList[i]);
            Debug.Log(transform.position);
            Instantiate(prefab, transform.position, new Quaternion());
            i += 1;
        }
    }
}

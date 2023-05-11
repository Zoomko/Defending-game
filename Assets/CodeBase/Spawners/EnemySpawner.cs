using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void Spawn(GameObject gameObject)
    {
        gameObject.transform.position = transform.position;
    }
}

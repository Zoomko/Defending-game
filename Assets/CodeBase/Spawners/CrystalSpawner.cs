using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public void Spawn(GameObject gameObject)
    {
        gameObject.transform.position = transform.position;
    }
}

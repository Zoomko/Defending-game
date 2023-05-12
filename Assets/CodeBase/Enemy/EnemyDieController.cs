using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieController : MonoBehaviour
{
    public Action<GameObject> Died;
    public void Die()
    {
        Died?.Invoke(gameObject);
    }
}

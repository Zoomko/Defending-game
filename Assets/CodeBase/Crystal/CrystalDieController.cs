using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDieController : MonoBehaviour
{
    public event Action HasDestroyed;
    public void Die()
    {
        HasDestroyed?.Invoke();
    }
}

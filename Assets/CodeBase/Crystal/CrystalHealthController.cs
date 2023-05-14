using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CrystalDieController))]
public class CrystalHealthController : MonoBehaviour, IDamagable
{
    public event Action<int, int, int> HealthChanged;

    private CrystalDieController _dieController;

    private int _maxHealth;
    private int _health;
    public void Constructor(GameStaticData gameStaticData)
    {
        _maxHealth = gameStaticData.CrystalHP;
        _health = _maxHealth;
    }
    private void Awake()
    {
        _dieController = GetComponent<CrystalDieController>();
    }

    public void GetDamage(int value)
    {
        var result = Mathf.Max(0, _health - value);
        if (result == 0)
        {
            _dieController.Die();
        }
        HealthChanged?.Invoke(result, _maxHealth, value);
        _health = result;
    }
}

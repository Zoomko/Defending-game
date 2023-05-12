using Assets.CodeBase.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _healthImageTarget;
    private IDamagable _damagable;
    private Transform _cameraTransform;

    private void Awake()
    {
        _damagable = GetComponentInParent<IDamagable>();
        _damagable.HealthChanged += OnHealthChange;
    }
    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    public void OnHealthChange(int currentHp, int maxHp, int damage)
    {
        _healthImageTarget.fillAmount = ((float)currentHp) / maxHp;
    }

    private void LateUpdate()
    {
        transform.LookAt(_cameraTransform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/Player", fileName = "PlayerStaticData")]
public class PlayerStaticData : ScriptableObject
{
    [Header("Characteristics")]
    public float MovementSpeed;
    public float AttackSpeed;
    public int HP;

    [Header("Bullet")]
    public int BulletDamage;
    public float BulletLiveTime;
    public float BulletSpeed;
    [Space]
    public GameObject PlayerPrefab;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "MyGame/EnemyData")]
public class UnitData: ScriptableObject
{
    public float life;
    public float speed;
    public float Damage;
    public int UnitPrice;
    public int unitType;
}

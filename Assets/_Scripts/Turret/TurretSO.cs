using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret", menuName = "SO/Turret")]

public class TurretSO : ScriptableObject
{
    public TurretClass turretClass;
    public int level;
    public float turretMaxHP;
    public float turretDamage;
    public float turretAttackSpeed;
}

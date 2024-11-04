using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public EnemyName enemyName;
    public EnemyType enemyType;
    public int level;
    public float hp;
    public float speed;
    public float damage;
    public int gold;
    public int exp;    
}

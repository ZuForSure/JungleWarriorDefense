using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "SO/Bullet")]

public class BulletSO : ScriptableObject
{
    public int damage = 1;
    public float speed = 10f;
}

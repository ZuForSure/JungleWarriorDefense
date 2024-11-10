using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "SO/Hero")]

public class HeroSO : ScriptableObject
{
    public HeroClass heroClass;
    public Sprite avatar;
    public int level;
    public float damage;
    public float moveSpeed;
    public float attackSpeed;
}

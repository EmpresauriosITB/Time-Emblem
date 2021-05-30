using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyTeam")]
public class EnemyTeam : ScriptableObject
{
    public List<EnemyData> enemies;
}

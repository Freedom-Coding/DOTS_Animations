using System.Collections.Generic;
using Unity.Entities;

public class EnemyDataContainer : IComponentData
{
    public List<EnemyData> enemies;
}

public struct EnemyData
{
    public int level;
    public Entity prefab;
    public float health;
    public float damage;
    public float moveSpeed;
}
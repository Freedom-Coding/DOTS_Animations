using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public int level;
    public GameObject prefab;
    public float health;
    public float damage;
    public float moveSpeed;
}

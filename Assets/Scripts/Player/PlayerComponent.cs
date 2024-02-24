using Unity.Entities;

public struct PlayerComponent : IComponentData
{
    public float MoveSpeed;
    public float ShootCooldown;
    public Entity BulletPrefab;
}

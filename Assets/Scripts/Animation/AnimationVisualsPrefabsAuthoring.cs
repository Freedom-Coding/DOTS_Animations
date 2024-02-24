using Unity.Entities;
using UnityEngine;

public class AnimationVisualsPrefabsAuthoring : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemySkeletonPrefab;

    private class AnimationVisualsPrefabsBaker : Baker<AnimationVisualsPrefabsAuthoring>
    {
        public override void Bake(AnimationVisualsPrefabsAuthoring authoring)
        {
            Entity playerPrefabEntity = GetEntity(TransformUsageFlags.None);

            AddComponentObject(playerPrefabEntity, new AnimationVisualsPrefabs
            {
                Player = authoring.playerPrefab,
                EnemySkeleton = authoring.enemySkeletonPrefab
            });
        }
    }
}

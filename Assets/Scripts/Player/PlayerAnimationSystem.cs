using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;

public partial struct PlayerAnimationSystem : ISystem
{
    private EntityManager entityManager;

    private void OnUpdate(ref SystemState state)
    {
        if (!SystemAPI.ManagedAPI.TryGetSingleton(out AnimationVisualsPrefabs animationVisualPrefabs))
        {
            return;
        }

        entityManager = state.EntityManager;

        EntityCommandBuffer ECB = new EntityCommandBuffer(Allocator.Temp);

        foreach (var(transform, playerComponent, entity) in SystemAPI.Query<LocalTransform, PlayerComponent>().WithEntityAccess())
        {
            if (!entityManager.HasComponent<VisualsReferenceComponent>(entity))
            {
                GameObject playerVisuals = Object.Instantiate(animationVisualPrefabs.Player);

                ECB.AddComponent(entity, new VisualsReferenceComponent { gameObject = playerVisuals });
            }
            else
            {
                VisualsReferenceComponent playerVisualsReference = entityManager.GetComponentData<VisualsReferenceComponent>(entity);

                playerVisualsReference.gameObject.transform.position = transform.Position;
                playerVisualsReference.gameObject.transform.rotation = transform.Rotation;

                InputComponent inputComponent = SystemAPI.GetSingleton<InputComponent>();
                playerVisualsReference.gameObject.GetComponent<Animator>().SetBool("IsWalking", math.length(inputComponent.movement) > 0f);
            }

        }

        ECB.Playback(entityManager);
        ECB.Dispose();
    }
}
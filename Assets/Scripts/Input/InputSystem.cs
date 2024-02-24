using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using UnityEngine;

public partial class InputSystem : SystemBase
{
    private Controls controls;

    protected override void OnCreate()
    {
        if (!SystemAPI.TryGetSingleton<InputComponent>(out InputComponent input))
        {
            EntityManager.CreateEntity(typeof(InputComponent));
        }

        controls = new Controls();
        controls.Enable();
    }

    protected override void OnUpdate()
    {
        Vector2 moveVector = controls.ActionMap.Movement.ReadValue<Vector2>();
        Vector2 mousePosition = controls.ActionMap.MousePosition.ReadValue<Vector2>();
        bool isPressingLMB = controls.ActionMap.Shoot.ReadValue<float>() == 1 ? true : false;

        SystemAPI.SetSingleton(new InputComponent { mousePos = mousePosition, movement = moveVector, pressingLMB = isPressingLMB });
    }
}

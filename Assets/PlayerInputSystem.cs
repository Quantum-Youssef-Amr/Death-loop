using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputActionAsset playerContrlos;
    private InputAction moveAction;

    public Vector2 MoveInputValue { get; private set; }

    private void Awake()
    {
        moveAction = playerContrlos.FindActionMap("Player").FindAction("Move");
        RegisterInputAction();
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }
    private void RegisterInputAction()
    {
        moveAction.performed += context => MoveInputValue = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInputValue = Vector2.zero;

    }
}

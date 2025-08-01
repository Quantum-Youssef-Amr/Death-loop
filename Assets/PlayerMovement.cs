using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 5;
    public PlayerInputSystem inputmanager;


    private CharacterController pl_controller;
    private Vector3 currentmovement;

    private void Awake()
    {
        pl_controller = GetComponent<CharacterController>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        float speed = moveSpeed;
        Vector3 inputDirection = new Vector3(inputmanager.MoveInputValue.x, inputmanager.MoveInputValue.y, 0);
        Vector3 playerDirection = transform.TransformDirection(inputDirection);
        playerDirection.Normalize();
        currentmovement.x = playerDirection.x * speed;
        currentmovement.y = playerDirection.y * speed;
        pl_controller.Move(currentmovement * Time.deltaTime);

    }
}

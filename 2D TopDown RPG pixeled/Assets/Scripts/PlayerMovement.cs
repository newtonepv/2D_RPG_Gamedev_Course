using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float mooveSpeed;
    Vector2 movement;
    Rigidbody2D rb;
    PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }
    void Update()
    {
        GetMovementInput();

        Debug.Log(movement.ToString());
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector2 delta2d = movement * mooveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position+new Vector3(delta2d.x, delta2d.y,0));
    }
    void GetMovementInput()
    {
        movement = playerInputActions.Player.Move.ReadValue<Vector2>();
    }
}

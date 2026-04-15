using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputSystem_Actions inputs;

    public int str;
    public int dtx;
    public int spd;


    public Vector2 MoveInput;

    private void Awake()
    {
        inputs = new();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ExcecuteMovement;
    }

   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ExcecuteMovement(InputAction.CallbackContext context)
    {
       // if (!GameManager.instance.EnablePlayerTurn) return;

        Vector3 move = transform.forward * MoveInput.y + transform.right * MoveInput.x;
        move.Normalize();


        transform.position += move * GameManager.TileValue;

        if(move != Vector3.zero)
            transform.forward = move;

        print("aaa");
        GameManager.instance.OnPassTurn?.Invoke();

    }
}

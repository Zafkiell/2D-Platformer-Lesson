using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControl controls;
    InputAction move;

    public CharacterController2D controller;

    float horizontalMove = 0;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    private void Awake()
    {
        controls = new PlayerControl();
        move = controls.Gameplay.Move;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        horizontalMove = controls.Gameplay.Move.ReadValue<float>() * runSpeed;
        print("Horizontal move:" + horizontalMove);
        //Jump
        controls.Gameplay.Jump.performed += ctx => jump = true;
        //Crouching
        controls.Gameplay.Crouch.performed += ctx => crouch = true;
        controls.Gameplay.Crouch.canceled += ctx => crouch = false;
    }
    void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}

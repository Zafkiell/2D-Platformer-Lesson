using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControl controls;

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    private void Awake()
    {
        controls = new PlayerControl();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        horizontalMove = controls.Gameplay.Move.ReadValue<float>() * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //Jump
        controls.Gameplay.Jump.performed += ctx => jump = true;
        controls.Gameplay.Jump.performed += ctx => animator.SetBool("isJumping", true);
        //Crouching
        controls.Gameplay.Crouch.performed += ctx => crouch = true;
        controls.Gameplay.Crouch.canceled += ctx => crouch = false;
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
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

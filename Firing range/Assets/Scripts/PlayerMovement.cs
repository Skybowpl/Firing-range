using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    private CharacterController controller;
    private Vector3 velocity;
    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical; 
        characterController.Move(move * speed * Time.deltaTime);

        velocity += Physics.gravity * Time.deltaTime;

        controller.Move(velocity); // Apply Gravity

        if (controller.isGrounded) velocity = Vector3.zero;

    }
}

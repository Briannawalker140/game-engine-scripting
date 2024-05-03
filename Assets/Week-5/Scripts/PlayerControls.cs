using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float rotationVertical = 5.0f;
    [SerializeField] float rotationHorizontal = 5.0f;
    [SerializeField] Lava lava;

    PlayerControllerMappings playerMappings;

    private float mouseDeltaX = 0f;
    private float mouseDeltaY = 0f;
    private float cameraRotX = 0f;
    private int rotDir = 0;
    //private bool grounded;

    InputAction move;
    InputAction fire;
    InputAction jump;
    InputAction look;

    Rigidbody rb;
  //private bool hasKey;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerMappings = new PlayerControllerMappings();
        move = playerMappings.Player.Move;

        fire = playerMappings.Player.Fire;
        fire.performed += Fire;

        jump = playerMappings.Player.Jump;
        jump.performed += Jump;

        look = playerMappings.Player.Look;
        
    }

    private void OnEnable()
    {
        move.Enable();
        fire.Enable();
        jump.Enable();
        look.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        jump.Disable();
        look.Disable();
    }

    private void Update()
    {
        HandleHorizontalRotation();
        HandleVerticalRotation();
    }


    /*private void FixedUpdate()
    {
        grounded = IsGrounded();

        HandleMovement();
    }

    void HandleMovement()
    {
        if (grounded == false) return;

        Vector2 axis = move.ReadValue<Vector2>();

        Vector3 input = (axis.x * transform.right) + (transform.forward * axis.y);

        input *= speed;

        rb.velocity = new Vector3(input.x, rb.velocity.y, input.y);
    }

    bool IsGrounded()
    {
        //Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 3;

        RaycastHit hit;

        //Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.yellow); 
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * -1) *1000, Color.white);
            return false;
        }
    }*/

    void HandleHorizontalRotation()
    {
        mouseDeltaX = look.ReadValue<Vector2>().x;

        if (mouseDeltaX != 0)
        {
            rotDir = mouseDeltaX > 0 ? 1 : -1;

            transform.eulerAngles += new Vector3(0, rotationHorizontal * Time.deltaTime * rotDir, 0);
        }
    }

    void HandleVerticalRotation()
    {
        mouseDeltaY = look.ReadValue<Vector2>().y;

        if (mouseDeltaY != 0)
        {
            rotDir = mouseDeltaY > 0 ? -1 : 1;

            cameraRotX += rotationVertical * Time.deltaTime * rotDir;
            cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

            var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);


            //Vector3 angle = new Vector3(rotation * Time.deltaTime * rotDir, 0, 0);

            Debug.Log(Camera.main.transform.localRotation.x);

            Camera.main.transform.localRotation = targetRotation;
            //Camera.main.transform.Rotate(angle, Space.Self);

        }
    }
    void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        Vector3 direction = (input.x * transform.right) + (transform.forward * input.y);

        transform.position = transform.position + (direction * speed * Time.deltaTime);
    }

    void Fire(InputAction.CallbackContext context)
    {
        
    }

    void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public int health = 20;

    public void TakeDamage(int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


      private void OnTriggerEnter(Collider other)
      {
          if (other.transform.tag == "Lava") TakeDamage();
          
      }

    private void TakeDamage()
    {
        throw new NotImplementedException();
    }
}

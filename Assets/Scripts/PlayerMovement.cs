using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController PlayerController;

    [SerializeField] private float MouseSensitivity = 5f;
    [SerializeField] public float MovmentSpeed = 4f;
    [SerializeField] private float JumpForce = 12f;
    private float Gravity = -9.81f;

    private Vector3 Velocity;
    private Vector3 PlayerMovmentInput;
    private Vector2 PlayerMouseInput;
    private float CamXRoataion;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerMovmentInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        move();
        Look();
    }

    void move()
    {

        Vector3 MoveVector = transform.forward * PlayerMovmentInput.z + transform.right * PlayerMovmentInput.x;

        if (PlayerController.isGrounded)
        {
            Velocity.y = -3f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velocity.y = JumpForce;
            }
        }
        else
        {
            Velocity.y -= Gravity * -2f * Time.deltaTime;
        }

        PlayerController.Move(MoveVector * MovmentSpeed * Time.deltaTime);
        PlayerController.Move(Velocity * Time.deltaTime);
    }

    void Look()
    {
        CamXRoataion -= PlayerMouseInput.y * MouseSensitivity;

        transform.Rotate(0f, PlayerMouseInput.x, 0f);
        PlayerCamera.localRotation = Quaternion.Euler(CamXRoataion, 0f, 0f);

    }

}

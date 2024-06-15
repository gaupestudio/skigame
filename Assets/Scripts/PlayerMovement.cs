using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float GRAVIITY = -9.81f;

    public CharacterController controller;
    public float speed = 12f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask terrainMask;

    Vector3 velocity;
    bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, terrainMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += GRAVIITY * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

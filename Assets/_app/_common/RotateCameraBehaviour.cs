using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCameraBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private InputActionReference rotateAction;

    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private float rotationSpeed = 75;
    [SerializeField] private float moveSpeed = 1;

    private void FixedUpdate()
    {
        var rotate = rotateAction.action.ReadValue<Vector2>();
        rb.AddTorque(transform.up * rotate.x * rotationSpeed);

        var move = moveAction.action.ReadValue<Vector2>();
        // transform.position += (forward + right) * moveSpeed;
        // rb.velocity = transform.forward * move.y * moveSpeed;
        rb.AddForce(transform.forward * move.y * moveSpeed);
    }
}
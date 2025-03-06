using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCameraBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference rotateAction;

    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private float rotationSpeed = 75;
    [SerializeField] private Vector2 verticalAngleBoundaries = new(-75, 75);

    [SerializeField] private float moveSpeed = 5;

    private float m_Yaw;
    private float m_Pitch;

    private void Start()
    {
        m_Yaw = transform.eulerAngles.y;
        m_Pitch = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        var rotate = rotateAction.action.ReadValue<Vector2>() * (rotationSpeed * Time.deltaTime);

        m_Yaw += rotate.x;
        m_Pitch -= rotate.y; // Inversé pour correspondre aux mouvements naturels
        m_Pitch = Mathf.Clamp(m_Pitch, verticalAngleBoundaries.x, verticalAngleBoundaries.y);

        transform.rotation = Quaternion.Euler(m_Pitch, m_Yaw, 0f);

        var move = moveAction.action.ReadValue<Vector2>();

        var forward = transform.forward * move.y;
        var right = transform.right * move.x;

        transform.position += (forward + right) * (moveSpeed * Time.deltaTime);

    }
}
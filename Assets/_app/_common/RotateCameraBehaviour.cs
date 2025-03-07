using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCameraBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference rotateAction;
    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private float rotationSpeed = 75;
    [SerializeField] private Vector2 verticalAngleBoundaries = new(-75, 75);

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float drag = 3f;

    private Rigidbody rb;
    private float m_Yaw;
    private float m_Pitch;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Empêcher la tondeuse de tomber ou de tourner bizarrement
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        m_Yaw = transform.eulerAngles.y;
        m_Pitch = transform.eulerAngles.x;

        rb.drag = drag; // Ajoute un freinage naturel
    }

    private void LateUpdate()
    {
        // Gestion de la rotation de la caméra
        var rotate = rotateAction.action.ReadValue<Vector2>() * (rotationSpeed * Time.deltaTime);

        m_Yaw += rotate.x;
        m_Pitch -= rotate.y;
        m_Pitch = Mathf.Clamp(m_Pitch, verticalAngleBoundaries.x, verticalAngleBoundaries.y);

        transform.rotation = Quaternion.Euler(m_Pitch, m_Yaw, 0f);
    }

    private void FixedUpdate()
    {
        // Récupère l'entrée du joueur
        var move = moveAction.action.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(move.x, 0, move.y).normalized;

        // Applique une force uniquement si un input est donné
        if (moveDirection.magnitude > 0)
        {
            rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
        }

        // Limite la vitesse maximale
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}

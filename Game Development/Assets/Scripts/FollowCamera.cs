using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // Reference to the character's transform
    public float distance = 5.0f; // Distance from the character
    public float height = 2.0f; // Height of the camera above the character
    public float smoothSpeed = 10.0f; // Smoothness of camera movement

    public float rotationDamping = 3.0f; // Damping for camera rotation

    private Vector3 offset; // Offset between camera and character

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calculate desired position based on character's position and offset
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = target.position.y + height;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Calculate the desired rotation
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);

        // Smoothly rotate the camera towards the desired rotation using Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);
    }
}


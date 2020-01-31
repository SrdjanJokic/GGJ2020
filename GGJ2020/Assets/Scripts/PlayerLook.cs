using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody = null;
    [SerializeField] private Vector3 camPositionOnPlayer = Vector3.zero;
    [SerializeField] private float mouseSensitivity = 100f;

    private float xRot = 0f;

    private void OnEnable()
    {
        transform.parent = playerBody;
        transform.localPosition = camPositionOnPlayer;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
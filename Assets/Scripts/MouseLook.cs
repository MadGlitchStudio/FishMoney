using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 0.1f;


    private float rotationX;
    private float rotationY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Vector3 angles = transform.localEulerAngles;

        rotationY = angles.y;
        rotationX = angles.x;

        if (rotationX > 180f)
        {
            rotationX -= 360f;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isMobilePlatform)
        {
            return;
        }

        float mouseX = 0f;
        float mouseY = 0f;

        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            rotationY += mouseDelta.x * mouseSensitivity;
            rotationX -= mouseDelta.y * mouseSensitivity;
        }

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}

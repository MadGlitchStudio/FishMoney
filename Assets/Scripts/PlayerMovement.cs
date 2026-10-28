using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2.5f;
    public Transform vrCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vrCamera == null || Keyboard.current == null)
        {
            return;
        }

        Vector3 moveDirection = Vector3.zero;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            moveDirection += vrCamera.forward;
        }
        //if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        //{
        //    moveDirection -= vrCamera.forward;
        //}
        //if (Keyboard.current.aKey.isPressed)
        //{
        //    moveDirection -= vrCamera.right;
        //}
        //if (Keyboard.current.dKey.isPressed)
        //{
        //    moveDirection += vrCamera.right;
        //}
        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }
}


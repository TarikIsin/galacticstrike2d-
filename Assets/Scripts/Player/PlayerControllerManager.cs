using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 8f;

    [Header("Boundary Settings")]
    [SerializeField] float minX = -4f;
    [SerializeField] float maxX = 4f;
    [SerializeField] float minY = -7f;
    [SerializeField] float maxY = 2f;

    private void Update()
    {
        Vector2 input = GetInputVector();
        MovePlayer(input);
        ClampPlayerPosition();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FireBullet();
        }
    }

    private Vector2 GetInputVector()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current == null) return input;

        bool movingUp = Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed;
        bool movingDown = Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed;
        bool movingRight = Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed;
        bool movingLeft = Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed;

        if (movingUp) input.y += 1f;
        if (movingDown) input.y -= 1f;
        if (movingRight) input.x += 1f;
        if (movingLeft) input.x -= 1f;

        return input;
    }

    private void MovePlayer(Vector2 input)
    {
        Vector3 movement = new Vector3(input.x, input.y, 0f);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void ClampPlayerPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private void FireBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
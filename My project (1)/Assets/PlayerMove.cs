using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick easyJoystick;
    public Rigidbody rb;
    public float moveSpeed = 5f;

    void FixedUpdate()
    {
        // Определение направления движения
        float horizontal = easyJoystick.Horizontal;
        float vertical = easyJoystick.Vertical;

        // Перемещение игрока
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Поворот игрока
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }

}

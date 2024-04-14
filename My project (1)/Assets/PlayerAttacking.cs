using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] LineRenderer LR;
    [SerializeField] Joystick AttackJoystick;
    [SerializeField] Transform AttackLookAtPoint;
    [SerializeField] public float trailDistance;
    [SerializeField] Transform player;
    [SerializeField] float aimLineMaxLength = 5f;
    [SerializeField] float aimLineMinLength = 1f;
    [SerializeField] float aimLineRotationSpeed = 50f;
    [SerializeField] public int NoOfBullets;
    [SerializeField] Transform Bullet; // Используйте Prefab вместо Transform
    bool Shoot;
    RaycastHit hit;

    void Start()
    {
        Shoot = false;
        trailDistance = aimLineMaxLength;
    }

    void Update()
    {
        if (Mathf.Abs(AttackJoystick.Horizontal) > 0.2f || Mathf.Abs(AttackJoystick.Vertical) > 0.2f)
        {
            // Включить линию атаки
            LR.enabled = true;

            // Управление вращением персонажа
            float horizontal = AttackJoystick.Horizontal;
            float vertical = AttackJoystick.Vertical;
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (direction != Vector3.zero)
            {
                player.rotation = Quaternion.LookRotation(direction);
            }

            // Управление длиной линии атаки
            float currentAimLineLength = aimLineMaxLength + (AttackJoystick.Vertical * (aimLineMaxLength - aimLineMinLength));
            LR.SetPosition(0, player.position);
            if (Physics.Raycast(player.position, player.forward, out hit, trailDistance))
            {
                LR.SetPosition(1, hit.point);
            }
            else
            {
                LR.SetPosition(1, player.position + player.forward * currentAimLineLength);
            }
            if (Shoot == false)
            {
                Shoot = true;
            }
        }
        else if (Shoot && Input.GetMouseButtonUp(0))
        {
            // Создание экземпляра пули с помощью префаба
            StartCoroutine(ShootBullet());
            Shoot = false;
        }
        else
        {
            // Выключить линию атаки
            LR.enabled = false;
            Shoot = false;
        }
        
    }
    IEnumerator ShootBullet()
    {
        for (int i = 0; i < NoOfBullets; i++) // Добавлен оператор ';' после NoofBullets
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(Bullet, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float rotationSpeed = 5;

    private Vector3 targetPosition;

    public void Movement()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

    public void Aim(Vector2 input)
    {
        Ray ray = Camera.main.ScreenPointToRay(input);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);

            // Tetapkan tinggi karakter agar tidak mempengaruhi posisi vertikalnya
            targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            // Periksa apakah pemain sudah mendekati atau berada di posisi target
            if (Vector3.Distance(transform.position, targetPosition) > .5f)
            {
                // Rotasi karakter ke arah posisi target
                Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                
                SetMoveSpeed();
            }
            else
            {
                StopMoveSpeed();
            }
        }
    }

    private void SetMoveSpeed()
    {
        moveSpeed = 5;
    }

    private void StopMoveSpeed()
    {
        moveSpeed = 0;
    }
}

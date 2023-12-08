using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private GameObject target;
    public float moveSpeed = 5f;
    public float stoppingPercentage = 0.75f; 

    private Vector3 spawnPoint;
    private float totalDistance;

    private void Start()
    {
        target = GameObject.Find("SpaceShip");

        spawnPoint = transform.position;
        totalDistance = Vector3.Distance(spawnPoint, target.transform.position);
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            float distanceToTarget = direction.magnitude;

            if (distanceToTarget > totalDistance * stoppingPercentage)
            {
                direction.Normalize();
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
            else
            {

            }
        }
    }
}

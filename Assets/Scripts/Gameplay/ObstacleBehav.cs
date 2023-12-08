using UnityEngine;

public class ObstacleBehav : MonoBehaviour
{
    private GameObject target;  
    public float moveSpeed = 5f;

    private void Start()
    {
        target = GameObject.Find("SpaceShip");
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;

            direction.Normalize();

            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}

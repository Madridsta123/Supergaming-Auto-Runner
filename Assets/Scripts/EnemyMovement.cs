using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed; // Speed at which the enemy moves

    void Update()
    {
        // Move the enemy forward
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}

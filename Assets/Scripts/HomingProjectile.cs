using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 200f;
    private Transform target;

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.localEulerAngles).x;
        transform.Rotate(0, rotateAmount * rotationSpeed * Time.deltaTime, 0);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}

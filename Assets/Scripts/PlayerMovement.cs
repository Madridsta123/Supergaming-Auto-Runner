using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] enemyprfab;
    [SerializeField] private GameObject projectileprefab;
    // Start is called before the first frame update
    [SerializeField] private float mindistance;
    private PlayerInputShape playerInput;
    private void Start()
    {
       playerInput = GetComponent<PlayerInputShape>();
      // CheckForEnmeies();
    }
    private void Update()
    {
        PlayerMove();
    }
   /* private void FixedUpdate()
    {
        PlayerMove();
    }*/
    void PlayerMove()
    {
        // rb.velocity = Vector3.forward * speed * Time.fixedDeltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (playerInput.lowerPart.GetComponentInChildren<Shape>().shapeType == other.GetComponent<Shape>().shapeType)
            {
                Destroy(other.gameObject);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
         if(other.CompareTag("Enemy"))
        {
            if (playerInput.upperPart.GetComponentInChildren<Shape>().shapeType == other.GetComponent<Shape>().shapeType)
                {
                for (int i = 0; i < enemyprfab.Length; i++)
                { 
                    ShootProjectile(other.transform);
                }
                
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
   
    void ShootProjectile(Transform target)
    {
        GameObject projectile = Instantiate(projectileprefab, this.transform.position, Quaternion.identity);
        HomingProjectile homingProjectile = projectile.GetComponent<HomingProjectile>();
        homingProjectile.SetTarget(target);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    bool isEnemy;

    private void Update()
    {
        if (!isEnemy)
        {
            Destroy(gameObject, 1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isEnemy = true;
            Destroy(gameObject);
        }
    }
}

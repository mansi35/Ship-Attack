using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        health Health = hit.transform.parent.GetComponent<health>();

        if (Health != null)
        {
            Health.TakeDamage(10);
        }

        // Destroy(gameObject);
    }
}

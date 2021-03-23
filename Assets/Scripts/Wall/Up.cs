using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(1000, transform.position, 60, 5);
    }
}

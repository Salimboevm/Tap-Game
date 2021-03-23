using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongCubeManager : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(350, transform.position, 10, 0.5f);
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(350, transform.position, 10, 0.5f);
    }
}

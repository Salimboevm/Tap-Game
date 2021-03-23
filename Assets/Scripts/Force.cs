using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public new string name;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != name)
        {
            collision.rigidbody.AddExplosionForce(500, transform.position, 10, 0.5f);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != name)
        {
            collision.rigidbody.AddExplosionForce(500, transform.position, 10, 0.5f);
        }
    }
}

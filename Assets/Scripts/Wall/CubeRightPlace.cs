using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRightPlace : MonoBehaviour
{
    public TargetManager target;
    public Vector3 position;
    public Vector3 force;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(target.resType) && target.Fill != 0)
        {
            other.gameObject.transform.rotation = Quaternion.identity;
            other.gameObject.transform.position = transform.position + Vector3.up;
        }
        else 
        {
            other.attachedRigidbody.AddExplosionForce(1000,transform.position,60,5);
        }
    }
}

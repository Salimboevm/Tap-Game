using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    public string name;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(name))
        {
            if (Tutorial.instance.started)
            {
                other.attachedRigidbody.isKinematic = false;
                
            }
            other.gameObject.transform.localEulerAngles = new Vector3(90, 0, 90);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(name))
            if (Tutorial.instance.started)
            {
                other.attachedRigidbody.isKinematic = true;
            }
    }

}

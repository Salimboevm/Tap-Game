using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    public Vector3 or;
    // Start is called before the first frame update
    public void Set()
    {
        or = transform.position;
    }
}

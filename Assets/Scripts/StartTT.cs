using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTT : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("train"))
            Tutorial.instance.StartTutorial();
    }
}

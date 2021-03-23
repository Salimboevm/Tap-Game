using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    float id = 0;
    public static Train instance;
    [HideInInspector]public float speed = 1.5f;
    public float minSpeed,maxSpeed;
    private void Awake()
    {

        speed = minSpeed;
        instance = this;
    }
    void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).Translate(speed * Time.fixedDeltaTime, 0, 0);
        }
        
    }
    public void UpdateSpeed()
    {
        id+=0.5f;
        speed = Mathf.Lerp(minSpeed, maxSpeed, id);
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUp : MonoBehaviour
{
    public static WaterUp instance;

    private void Awake()
    {
        instance = this;
    }

    public void Up()
    {
        float x = gameObject.transform.position.x;

        gameObject.transform.position = new Vector3();
    }
}

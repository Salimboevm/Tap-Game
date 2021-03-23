using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Change();
public class Changer : MonoBehaviour
{
    Renderer z;

    Material[] material;
    private void Awake()
    {
        material = new Material[2];
        z = gameObject.GetComponent<Renderer>();
    }
    void Start()
    {
        //int id = MyRandom(0,
        //        LevelManager.instance.materials.Length - 1);
        ResType color = LevelManager.instance.GetRandomRes();
        material[0] = z.sharedMaterials[0];
        material[1] = color.material;
        
        z.sharedMaterials = material;
        
        gameObject.tag = color.colorName;
    }

    int randomSeed = 0;
    int MyRandom(int min, int max)
    {
        randomSeed += 5;
        UnityEngine.Random.InitState(randomSeed += (int)System.DateTime.Now.Millisecond);

        return Random.Range(min, max);
    }
}

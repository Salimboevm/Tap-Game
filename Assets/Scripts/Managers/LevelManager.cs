using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Material[] materials;
    public Change change;
    public List<ResType> colors;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    public ResType GetRandomRes()
    {
        ResType color = colors[Random.Range(0, colors.Count)];
        color.Add();
        return color;
    }
}
[System.Serializable]
public class ResType
{
    public static bool isAllResCreated = false;
    int filled = 0;
    public Material material;
    public string colorName;
    public int RequiredResCount;
    public int currentResCount;

    public void Add()
    {
        currentResCount++;
        if (currentResCount >= RequiredResCount)
        {
            filled++;
            
            if (filled == LevelManager.instance.colors.Count)
            {
                ResType.isAllResCreated = true;
            }
            //LevelManager.instance.colors.Remove(this);
        }
    }
}
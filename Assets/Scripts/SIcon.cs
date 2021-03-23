using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SIcon : MonoBehaviour 
{
    public Sprite sprite1, sprite2;
    public RuUz[] imm;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
        image.overrideSprite = sprite1;

        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "ru");
            PlayerPrefs.Save();
        }
        string pplan = PlayerPrefs.GetString("Language","ru");
        if (pplan == "uz")
            Swap();
    }
    public void Swap()
    {
        if (image.overrideSprite == sprite1)
        {
            print("1");
            PlayerPrefs.SetString("Language","uz");
            PlayerPrefs.Save();
            image.overrideSprite = sprite2;
        }
        else
        {
            print("2");
            PlayerPrefs.SetString("Language", "ru");
            PlayerPrefs.Save();
            image.overrideSprite = sprite1;
        }
        foreach (RuUz item in imm)
        {
            item.Start();
        }
    }
	
}

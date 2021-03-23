using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuUz : MonoBehaviour
{
    public AudioClip InfoRu,InfoUz;
    public string ru, uz;
    public bool locilizeText = false;
    public Text text;
    public void Start()
    {
        text = GetComponent<Text>();
        string ruuz = PlayerPrefs.GetString("Language", "ru");
        if (locilizeText && text != null)
        {
            if (ruuz == "ru")
                text.text = ru;
            if (ruuz == "uz")
                text.text = uz;
        }
    }
}

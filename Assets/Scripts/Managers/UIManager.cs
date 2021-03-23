using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public CanvasGroup win,lose;


    private void Awake()
    {
        instance = this;
    }    
}

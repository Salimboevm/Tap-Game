using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTween {
    public static MyTween instance;
    public MyTween()
    {
        instance = this;
    }
    public IEnumerator Tween(Action<float> action, float a, float b, float duration = 1)
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float l = Mathf.Lerp(a, b, elapsed/duration);
            action.Invoke(l);
            yield return null;
        }
    }
    public IEnumerator Tween(Action<float> action,Action end,float a,float b,float duration = 1)
    {
        float elapsed = 0;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            
            float l = Mathf.Lerp(a, b, elapsed);
            action.Invoke(l);
            yield return null;
        }
        end.Invoke();
    }
}

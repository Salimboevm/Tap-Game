using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    public Texture[] textures;
    static int t_counter = 0;
    private void Awake()
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        mpb.SetTexture("_MainTex", textures[t_counter]);
        GetComponent<Renderer>().SetPropertyBlock(mpb);
        t_counter = (t_counter + 1) % textures.Length;
    }
}

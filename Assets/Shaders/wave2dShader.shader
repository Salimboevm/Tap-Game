Shader "Unlit/wave2dShader"
{
    Properties
    {
        _Color ("Color", COLOR) = (1,0.7,0.4,1)
        _LineColor ("Line Color", COLOR) = (0.63,0.18,0.16,1)
        _MainTex ("Texture", 2D) = "white" {}
        _Fill ("Fill", FLOAT) = 0.5
        [Space]
        _WaveSize ("Wave Size", FLOAT) = 0.02
        _WaveFreq ("Wave Frequency", FLOAT) = 10
        _WaveSpeed ("Wave Speed", FLOAT) = 2
        [Space]
        _LineScale ("Line Scale", FLOAT) = 1.33
        _LineHardness ("Line Hardness", FLOAT) = 0.3
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _LineColor;
            half _Fill;
            half _WaveSize;
            half _WaveFreq;
            half _WaveSpeed;

            half _LineScale;
            half _LineHardness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float mod(float v1,float v2){
                return frac(v1/v2)*v2;
            }
            float fake_cos(float v){
                float r4 = mod(v,4);
                float r2 = mod(r4,2)-1;
                return lerp(
                    r2*r2 - 1,
                    1 - r2*r2,
                    step(r4,2)
                );
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half wave = 0;
                wave += i.uv.y + fake_cos(i.uv.x*_WaveFreq + _Time.w*_WaveSpeed)*_WaveSize;
                wave += i.uv.y + fake_cos(i.uv.x*_WaveFreq*0.6 - _Time.z*_WaveSpeed*1.5)*_WaveSize;
                wave *= 0.5;
                wave -= _Fill;
                
                fixed4 col = tex2D(_MainTex, i.uv)* lerp(_LineColor, _Color, saturate(pow(abs(wave),_LineHardness)*_LineScale));
                col.a = step(wave, 0);
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}

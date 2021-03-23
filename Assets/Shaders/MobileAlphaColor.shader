
Shader "Mobile/AlphaToColor" {
Properties {
	_Specular ("Specular", Range (0.0, 2)) = 0.1
	_Hardness ("Specular Hardness", FLOAT) = 30
	_Color ("Color", COLOR) = (1,1,1,1)
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
}
SubShader { 
	Tags { "RenderType"="Opaque" }
	LOD 250
	
CGPROGRAM
#pragma surface surf MobileBlinnPhong exclude_path:prepass nolightmap noforwardadd halfasview

inline fixed4 LightingMobileBlinnPhong (SurfaceOutput s, fixed3 lightDir, fixed3 halfDir, fixed atten)
{
	fixed diff = max (0, dot (s.Normal, lightDir));
	fixed nh = max (0, dot (s.Normal, halfDir));
	fixed spec = pow (nh, s.Gloss) * s.Specular;
	
	fixed4 c;
	c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec) * (atten*2);
	c.a = 0.0;
	return c;
}

fixed4 _Color;
sampler2D _MainTex;
half _Specular;
half _Hardness;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	o.Albedo = lerp(_Color,tex.rgb,tex.a);
	o.Gloss = _Hardness;
	o.Alpha = tex.a;
	o.Specular = _Specular;
}
ENDCG
}

FallBack "Mobile/VertexLit"
}

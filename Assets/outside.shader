Shader "My_Shaders/outside-no-light" {
   Properties {
     _Color ("Main Color", Color) = (1,1,1,0.5) // Tint
     //_MainTex ("Texture", 2D) = "white" {}
     //_BumpMap ("Bumpmap", 2D) = "bump" {}
   }
 
   Subshader {
     Tags { "RenderType" = "Opaque" }
 
     CGPROGRAM
     #pragma surface surf SimpleLambert
     
     half4 LightingSimpleLambert (SurfaceOutput s, half3 lightDir, half atten) {
        half NdotL = dot (s.Normal, lightDir);
        half4 c;
        c.rgb = s.Albedo;
        c.a = s.Alpha;
     	return c;
     }
 
     struct Input {
       float4 color : COLOR; // Vertex Color
       //float2 uv_MainTex;
       //float2 uv_BumpMap;
     };
 
     float4 _Color; // Tint
     sampler2D _MainTex;
     //sampler2D _BumpMap;
 
     void surf (Input IN, inout SurfaceOutput o) {
       //o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * IN.color.rgb * _Color; // Texture * Vertex Color * Tint
       o.Albedo = IN.color.rgb * _Color;
       //o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
     }
     ENDCG
 
   }
   Fallback "Diffuse"
}
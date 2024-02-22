## AR Portal in Universal RP
Unity 2022.3.15f1c1  
Universal RP 14.0.9  
AR Foundation 5.1.2  
Apple ARKit XR Plugin 5.1.2  

## :one: Impossible Box
### Introduction
Stencil function can be achieved through `Renderer Feature` in `Universal Renderer Data` to create portal effect. Through each portal the specific gameobjects can be seen and the maximum quantity of portals is 15 due to  `Universal Renderer Data`.
### Key Assets
`Assets/RP/ArPortal_Renderer.asset`  
>Filtering  
>>`Opaque Layer Mask` Portal n and InWorld n should be unchecked.  
>>`Transparent Layer Mask` Portal n and InWorld n should be unchecked.  
>Portal n  
>>`Event` BeforeRenderingOpaques  
>>`Filter`  
>>>`LayerMask` Portal n  
>>`Overrides`  
>>>`Stencil` Checked  
>>>>`Value` n  
>>>>`Compare Function` Equal  
>>>>`Fail` Replace  
>World n  
>>`Event` AfterRenderingOpaques  
>>`Filter`  
>>>`LayerMask` World n  
>>`Overrides`  
>>>`Stencil` Checked  
>>>>`Value` n  
>>>>`Compare Function` Equal  
`Layer` of `gameobject` portal should be set to Portal n and `gameobject` masked by the portal should be set to World n.  
### Scene Recording
![Impossible Box](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/ImpossibleBox.gif)  
## 2️⃣ Portable Door
![Portable Door](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/PortableDoor.gif)  
## 3️⃣ Portable Object
![Portable Object](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/PortableObject.gif)  
## 4️⃣ Dome Slider
### Introduction
Dome Slider has a `slider` in the right side of the screen which can be used to fade in and out `gameobject` Dome.  
### Key Assets
`DomeSlider.shadergarph` The `shader` of Dome's material
>Skybox Texture `Texture2D` a HDRI texture  
>Smoothness `Float` for better edge between skybox texture and reality world  
>Distance `Float` strength of VR  
### Scene Recording
![Dome Slider](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/DomeSlider.gif)  

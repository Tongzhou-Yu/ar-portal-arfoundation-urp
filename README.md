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
>`Filtering\Opaque Layer Mask` Portal n and InWorld n should be unchecked.  
>`Filtering\Transparent Layer Mask` Portal n and InWorld n should be unchecked.  
>`Portal n\Event` BeforeRenderingOpaques  
>`Portal n\Filter\LayerMask` Portal n  
>`Portal n\Overrides\Stencil` Checked  
>`Portal n\Overrides\Value` n  
>`Portal n\Overrides\Compare Function` Equal  
>`Portal n\Overrides\Fail` Replace  
>`World n\Event` AfterRenderingOpaques  
>`World n\Filter\LayerMask` World n  
>`World n\Overrides\Stencil` Checked  
>`World n\Overrides\Value` n  
>`World n\Overrides\Compare Function` Equal  
  
`Layer` of `gameobject` portal should be set to Portal n and `gameobject` masked by the portal should be set to World n.  
### Scene Recording
![Impossible Box](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/ImpossibleBox.gif)  
## 2️⃣ Portable Door
### Introduction
AR user can walk through the portal with AR device from AR experience to VR experience.  
### Key Assets
`Script` Portable Door as the component of `gameobject` Portal.  
### Scene Recording
![Portable Door](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/PortableDoor.gif)  
## 3️⃣ Portable Object
### Introduction
specific `gameobject` such as the blue ball in the scene can move through the portal from inner world to outer world.  
### Key Assets
`Script` Portable Object as the component of `gameobject` Portable Object.  
### Scene Recording
![Portable Object](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/PortableObject.gif)  
## 4️⃣ Dome Slider
### Introduction
Dome Slider has a `slider` in the right side of the screen which can be used to fade in and out `gameobject` Dome.  
### Key Assets
`DomeSlider.shadergarph` The `shader` of Dome's material
>Skybox Texture `Texture2D` a HDRI texture  
>Smoothness `Float` for better edge between skybox texture and reality world  
>Distance `Float` strength of VR
`DomeSlider.csharp` on `gameobject` Dome
### Scene Recording
![Dome Slider](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/DomeSlider.gif)  
## 5️⃣ Dome Transition
### Introduction
Skybox texture of the dome can be transited by a button and the name of the skybox should be shown in a inputfield which can be prompt input area for AIGC such as Skybox AI Generator by Blockade Labs.  
### Key Assets
`DomeTransition.csharp` on `gameobject` Dome  
>Textures `List<Texture2D>` HDRI textures  
>Switch Button `Button` switch to next skybox  
>Input Field `InputField`  
>Initial Transition Speed `float` main transition speed  
>Acceleration `float` the accelaration that when fade out will speed up transition and speed down when fade in  
>Maximum Transition Speed `float` for better user experience during transition  
>Minimum Transition Speed `float` for better user experience during transition  
### Scene Recording
![Dome Transition](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/DomeTransition.gif)  

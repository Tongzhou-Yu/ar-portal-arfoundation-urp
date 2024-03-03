## Get Flower from the mirror Touch Moon from the water
**镜花水月 Kyōka Suigetsu: Fower in the miror, moon on the water**  
This Unity project is for achieving the aesthetics above that is visible but cannot be touched and cannot be described in words. 
## Installation  
Unity 2022.3.15f1c1  
Universal RP 14.0.9  
AR Foundation 5.1.2  
Apple ARKit XR Plugin 5.1.2  
(optional, stable diffusion function required) Newtonsoft Json 3.2.1  

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
`PortalDoor.csharp` as the component of `gameobject` Portal which is the child of `gameobject` Portal Door.  
>Innerworld `gameobject` should be the parent of all the `gameobject` inside the portal, everything will be automatically controlled.  
>In World Layer `int` should be the number of `layer` InWorldN.  
>Out World Layer `int` should be the number of `layer` OutWorldN.  
### Scene Recording
![Portable Door](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/PortableDoor.gif)  
## 3️⃣ Portable Object
### Introduction
specific `gameobject` such as the blue ball in the scene can move through the portal from inner world to outer world.  
### Key Assets
`PortableObject.csharp` as the component of `gameobject` Portable Object which is the child of `gameobject` InnerWorld.  
>Innerworld `gameobject` should be the parent of all the `gameobject` inside the portal, everything will be automatically controlled.  
>In World Layer `int` should be the number of `layer` InWorldN.  
>Out World Layer `int` should be the number of `layer` OutWorldN.   
### Scene Recording
![Portable Object](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/PortableObject.gif)   
## 4️⃣ Half-cross Door
Animated Model used in this project "Whale" (https://skfb.ly/6SF9s) by rkuhlf is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).  
## 5️⃣ Dome Slider
### Introduction
Dome Slider has a `slider` in the right side of the screen which can be used to fade in and out `gameobject` Dome.  
### Key Assets
`DomeSlider.shadergarph` The `shader` of Dome's material
>Skybox Texture `Texture2D` a HDRI texture  
>Smoothness `Float` for better edge between skybox texture and reality world  
>Distance `Float` strength of VR

`DomeSlider.csharp` on `gameobject` Dome  
>Slider `Slider` control the level of transition of skybox  
### Scene Recording
![Dome Slider](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/DomeSlider.gif)  
## 6️⃣ Dome Transition
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
## 7️⃣ Dome Transition Stable Diffusion
### Introduction  
This sample upgrade Dome Transition into a AIGC project that you can type prompt to have AI generated skybox texture on the dome. 
### Installation  
1. Stable Diffusion WebUI is required. I have made a basic Unity project [RuntimeSD](https://github.com/Tongzhou-Yu/RuntimeStableDiffusion) for using stable diffusion in realtime through the app you build to connect with your stable diffusion API. You can follow the instruction to install SD.
2. Adding `Launching Web UI with arguments:` `--api` `--share` to the command line options in `webui-user.bat` will generate a random share link that is displayed in the command window, that you can fill in `DomeTransition_RuntimeSD.csharp`'s `Url`.  
3. [360 Diffusion LoRA](https://civitai.com/models/26815/360-diffusion-lora-for-sd-15) is required for Stable Diffusion in this project. This LoRA model should be put in ..\webui\models\Lora.    
### Key Assets
`DomeTransition_RuntimeSD.csharp` on `gameobject` Dome  
### Scene Recording
![Dome Transition Stable Diffusion](https://github.com/Tongzhou-Yu/ar-portal-arfoundation-urp/blob/main/ScreenRecordingGIF/DomeTransition_StableDiffusion.gif)  


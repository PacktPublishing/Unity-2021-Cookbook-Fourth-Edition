# Unity-2021-Cookbook
Unity 2021 Cookbook (Fourth Edition), published by Packt

<a href="https://www.packtpub.com/game-development/unity-2020-cookbook"><img src="/images/cover2021.png" alt="Unity 2021 Cookbook" height="256px" align="right"></a>

This is the code repository for [Unity 2021 Cookbook](https://www.packtpub.com/game-development/unity-2020-cookbook), published by Packt.

**Over 160 recipes to take your 2D and 3D game and virtual reality development to the next level**

## What is this book about?
With the help of the Unity 2021 Cookbook, you’ll discover how to make the most of the UI system, learn to work with external resources and files, and understand how to animate both 2D and 3D characters and game scene objects using Unity's Mecanim animation toolsets.

This book covers the following exciting features: 
* Get creative with Unity’s shaders and learn to build your own shaders with the Shader Graph tool
* Create a text and image character dialog with the free Fungus Unity plugin
* Explore new features integrated into Unity 2021, including Code Coverage, the new Input System, and ProBuilder integration
* Add audio elements to your games, including sound effects and background music
* Intelligently control camera movements using the Cinemachine and timeline features
* Learn to create AR and VR games with Unity, and publish on the web as WebXR


If you feel this book is for you, get your [copy](https://www.packtpub.com/product/unity-2021-cookbook-fourth-edition/9781839217616) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>


## Instructions and Navigations
All of the code is organized into folders. For example, Chapter01.

The code will look like the following:
```
using UnityEngine; 
using System.Collections; 

public class ScrollZ : MonoBehaviour { 
  public float scrollSpeed = 20; 

  void Update () { 
    Vector3 pos = transform.position; 
    Vector3 localVectorUp = transform.TransformDirection(0,1,0); 
    pos += localVectorUp * scrollSpeed * Time.deltaTime; 
    transform.position = pos; 
  } 
} 
```

**Following is what you need for this book:**

With the following software and hardware list you can run all code files present in the book (Chapter 1-19).

### Software and Hardware List

| Chapter  | Software required         | Operating System               | Graphics card - GPU                            |
| -------- | --------------------------| -------------------------------| -----------------------------------------------|
| all      | Unity 2021.1 or later     | Windows 64-bit 7SP1 / 10       | DX10, DX11, DX12 capable                       |
| all      | Unity 2021.1 or later     | Mac OS X 10.12.6+              | Metal-capable (Intel or AMD)                   |
| all      | Unity 2021.1 or later     | Ubuntu 16.04 / 18.04 / CentOS 7| OpenGL 3.2+ or Vulkan-capable, Nvidia and AMD  |

Check [here](https://docs.unity3d.com/Manual/system-requirements.html#editor) for latest Unity editor requirements 

### Related products <Other books you may enjoy>

(links here)

## Get to Know the Authors

- [**Matt Smith**](https://github.com/dr-matt-smith)

    - is computing senior lecturer at the Technological University of Dublin, Ireland.
        
    - Matt been programming games since the Sinclar ZX80 and submitted 2 games for his computing O-level exam at the age of 16 in 1983 (he only got a 'B' grade - a scandal!). After a year of commercial business programming in the late 80s he decided to become a full time academic, researching and lecturering at Aberdeen University (Scotland), the Open University (UK), Winchester University (UK), Middlesex University (UK), and since 2002 at what is now TU Dublin (Ireland). He leads the [**DRIVE**](http://drive-rg.ie/) research group in the Blanchardstown Campus in North Dublin.
    
- [**Shaun Ferns**](https://github.com/shaunferns)

    - is computing lecturer at the Technological University of Dublin, Ireland.

    - more here

### Suggestions and Feedback
(LINK) if you have any feedback or suggestions.

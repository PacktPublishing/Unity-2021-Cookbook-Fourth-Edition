# Unity-2020-Cookbook
Unity 2020 Cookbook (Fourth Edition), published by Packt

<a href="https://www.packtpub.com/game-development/unity-2020-cookbook"><img src="/images/cover.png" alt="Unity 2020 Cookbook" height="256px" align="right"></a>

This is the code repository for [Unity 2020 Cookbook](https://www.packtpub.com/game-development/unity-2020-cookbook), published by Packt.

**Over 160 recipes to take your 2D and 3D game and virtual reality development to the next level**

## What is this book about?
With the help of the Unity 2020 Cookbook, you’ll discover how to make the most of the UI system, learn to work with external resources and files, and understand how to animate both 2D and 3D characters and game scene objects using Unity's Mecanim animation toolsets.

This book covers the following exciting features: 
* Get creative with Unity’s shaders and learn to build your own shaders with the new Shader Graph tool
* Create a text and image character dialog with the free Fungus Unity plugin
* Explore new features integrated into Unity 2020, including AAA, BBB, CCC
* Add audio elements to your games, including sound effects and background music
* Intelligently control camera movements using the Cinemachine and timeline features
* Learn to create AR and VR games with Unity

## 4 free PDF chapters (chapters 16-19)

Chapters 16-19 wouldn't fit in the print edition, so we're making them available free to download! The PDFs are in the corresponding Github chapter folders (in a folder named `bonus_chapter_PDF`), and are a great place to start if you want to explore the style of Unity game recipes you'll find the in book.

If you feel this book is for you, get your [copy](https://www.packtpub.com/game-development/unity-2020-cookbook) today!

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
| all      | Unity 2020.1 or later     | Windows 64-bit 7SP1 / 10       | DX10, DX11, DX12 capable                       |
| all      | Unity 2020.1 or later     | Mac OS X 10.12.6+              | Metal-capable (Intel or AMD)                   |
| all      | Unity 2020.1 or later     | Ubuntu 16.04 / 18.04 / CentOS 7| OpenGL 3.2+ or Vulkan-capable, Nvidia and AMD  |

Check [here](https://docs.unity3d.com/Manual/system-requirements.html#editor) for latest Unity editor requirements 

### Related products <Other books you may enjoy>

(links here)

## Get to Know the Authors

- [**Matt Smith**](https://github.com/dr-matt-smith)

    - is computing senior lecturer at the Technological University of Dublin, Ireland.
        
    - Matt started computer programming on a brand new ZX80 and submitted 2 games for his computing O-level exam. After nearly 10 years as a full-time student on a succession of scholarships, he gained several degrees in computing, including a PhD in computational musicology.
    
- [**Shaun Ferns**](https://github.com/shaunferns)

    - is computing lecturer at the Technological University of Dublin, Ireland.

    - more here

### Suggestions and Feedback
(LINK) if you have any feedback or suggestions.

# arcadia-engine
Arcadia Engine is a game engine I implemented using C# and OpenGL. I wanted to learn C# and the .NET core properly, so I decided to use the opportunity to create a game engine. The goal was also to continue practicing using OpenGL, which I learned for the [slime-mold-sim](https://github.com/OchaKaru/slime-mold-sim/) I made late last year. I originally used OpenGL bindings for C#, created by [danc](https://www.youtube.com/@dancdev), but wanted to eventually use compute shaders, so I opted to use OpenTK 4.0+ for modern OpenGL bindings. I decided to use GLFW again, since I already have some experience using GLFW, again from the slime-mold-sim, and OpenTK had an implementation built in.

My biggest hurdle was making sense of the associations each class will have with each other. Eventually, I also had some trouble with using non-square textures, for example, sprite sheets.

I plan on using this game engine to create some evolution simulations and games in the future (specifically for sheep).

## Inspiration and References
I wanted to make a game engine for a while because I love the idea of coding everything in a project from scratch, with some exceptions... I'm not crazy. This game engine's design is inspired by Ian Parberry's LARC engine since I learned game programming on that engine. I followed some of danc's videos to get started on putting the pieces together. I had a behemoth in front of me and I used those tutorials to split up the load.

## Installing and Running the Project
The project was built in Visual Studios, so using NuGet to grab the OpenTK, NewtonSoft.JSON, and System.Drawing.Common packages.

# Using the Project
I will be creating documentation for using each part of the game engine.

## Project File Breakdown
```
To be added.
```

## License
GNU General Public License v3.0

# cross_raytracer

App that render raytracer for Sphere, Triangle or Plane.
After click on button, it start rendering points for specific object.


Task:
# Raytracer using C#
 
Implement a simple raytracer using C#. Divide project into two parts -- rendering library and GUI.
 
## Rendering Library
 
Design and implement a simple raytracing library. 
It should expose an interface *Raytracer* used to control and access the results of rendering. 
The only allowed dependencies are *System.Collections* and *System.Math*.
 
### Raytracer interface
 
Interface should provide the following methods.
 
* Define size of rendering canvas.
* Set camera position and up vector.
* Add scene lights defined by position and color.
* Define scene using objects, all objects are defined by position and color
    * Planes -- defined by point and vector
    * Triangles -- defined by three points
    * Spheres -- defined by point and radius
* Render scene and get the result (Use array of pixel represented by color).
* Focus on simplicity of interface and clean pure code.
 
## GUI
 
Create an application demonstrating library functionality. 
It should provide controls to manipulate the scene and get the result from the library. 
It can be either desktop or web based application.
 
* For desktop application use your favorite framework. The WPF and UWP are the preffered ones.
* For web based application use ASP.NET MVC with Web API.
 
Focus on user experience and clean code. Use core features available in the selected framework.

Thanks for having purchased the asset! If you have any questions or suggestions, please contact:
sergeyiwanski@gmail.com

This asset contains the following models of square and triangular shape: 
apple, 
apricot, 
kiwi, 
orange, 
pineapple, 
plum, 
watermelon. 

They can be broken apart, each model has from 3 to 5 parts.

You can see the asset capabilities by running the "Demo" scene from the "Scenes" folder.
WASD or Arrows - Move
Q or C - down
E or SpaceBar - up
Left mouse button - hit

!Warning!
The demo scene contains a control script with the standard settings of the project, if you change the Input settings, then there may be errors, in this case I recommend removing the CameraFps script from the camera and using your controller instead.

The _Utils folder contains a items necessary for the work of some functions of an asset, 
they are universally used in different projects and assets, therefore they are moved to a separate folder.

Models are scaled according to the size of the real world.
Mesh of each fruit +/- 300 vertices, 500 triangles.
Materials have a color maps.
All textures 1024x1024 are in PNG.

The CellFracture script is responsible for replacing fruits with their breaking copies.
When setting up your own fruit, you need to insert a replacement object inside the Cells_plefab. The object must be configured so that it is a root with child objects-parts. You do not need to insert each part, the script will find them yourself. You can also customize the optimization when objects should be deleted. 

OnBreakdown() method
--------------------------
To start the destruction process, you need to call the OnBreakdown() method, which is in the "CellFracture" component script. You can see an example of this call in the "SpikedBat" script.

Scripts contain detailed comments and hints in the Inspector.

The splash contains an animated texture of 4x4 frames, on a transparent background. The material and texture are configured in such a way that the particles are clearly visible on a black and white background, and even on the same color. When a splash appears, 2-5 particles are created, turned in random directions, slightly different sizes for greater realism. The particle effect is placed on the root of the fruit parts to be activated upon appearance.


Publisher page:
https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:26699

Support:
Sergey Iwanski	sergeyiwanski@gmail.com
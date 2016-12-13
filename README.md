# unity-lesson-2-colliders
An introduction to colliders in Unity.

##Essentials
Unity includes basic collision detection in several simple shape models--Box, Capsule and Sphere. With a combination of these three shapes you can model collision data for almost anything. Colliders can function as solid objects which bounce off of each other, or as "triggers", which set off some behavior when another collider enters its volume. We will build a simple example of both in today's lesson.

##Getting started
Open up the Unity project we made in the [last lesson.](https://github.com/SpaceToastCoastToCoast/intro-to-unity) You should have a flat plane with a sphere resting on top of it in your scene. Make sure the sphere can be controlled by user input before beginning this lesson. Both these topics are covered in the previous lesson linked above if you need to review.

###Adding colliders
When you create a basic 3D object from the Unity editor, it will already have a collider of the correct shape attached to it. You should see a Sphere Collider attached to your sphere in the Inspector tab. This collider makes your sphere solid, so that it can sit on the floor and bump into things. If you remove the Sphere Collider component using the gear icon in its corner, you should see your sphere falling through the floor when you press Play. That would make it pretty hard to play this game, so if you removed it, add it back using the Add Component button. This is how you add a collider to an existing object.

You can add an "invisible" collider to your scene much the same way: go to the GameObject menu and select Create Empty. This will add a GameObject to your scene with no properties. The only property it has is a Transform, which tells the game where it is. (All objects in Unity have a Transform.) Give it a BoxCollider component using the Add Component button. Select the BoxCollider component and change its scale so it looks like a wall. As long as it is taller than your sphere and as wide or long as the edges of your floor, you can make it any size you want.

Create four walls along each side of your floor. Now, your sphere stays on the playing field no matter where you move it.

#####Why do we need invisible colliders?
You may think, "I should be able to see my walls! Why do I need invisible ones?" Consider games where your character can go into buildings, like, for example, a Pokemon Center. From inside the building, you can't see the front wall, but if you try to walk through it, your character bumps into it and stops. The front wall is invisible because it would block your view of your character and everything inside the room. Most games use a combination of both, or use special walls that turn invisible when the camera gets too close to them.

###Triggers
The other application of invisible colliders is as triggers. When an object enters a collider that is marked as a trigger, it doesn't bounce off, but instead sets off an action in that object's script. Triggers do nothing without a script attached.

First, let's make sure the game knows our sphere is the Player. Click on the sphere and look at it in the Inspector tab. There should be a dropdown menu labeled "Tag". Click on it and select "Player".

Then, let's create our trigger collider. Create an empty object and give it a SphereCollider with a radius of 5. Place it in the corner of your level, with part of it extending into the level bounds, so that you can move your sphere into it during gameplay. Select the "Is Trigger" checkbox on this collider.

Next, create a new script named `Goal.cs` and attach it to your trigger. An example script is provided in this repository. We will be focusing on the methods OnTriggerEnter, OnTriggerStay and OnTriggerExit.

Most objects don't use all three of these methods at once. Each has their own specific purpose.

OnTriggerEnter fires once, when any collider enters the trigger. Because this includes things like walls and floors, we want to use `GameObject.CompareTag()` to check for the kind of object we want to respond to. Unity comes with a built in tag for Players, and you can create tags for enemies and other things using the Add Tag option in the Tag menu. You might use OnTriggerEnter to make an enemy attack or react to a player that enters its range.

OnTriggerStay fires once per frame while an object is staying in its volume. Unless you want it firing 60 times per second, you should add a timer to space it out. You could use OnTriggerStay to add damage to a player while the player is in an area of hot lava.

OnTriggerExit fires once, when an object that has already entered the trigger leaves the trigger area. You might use this to change an enemy's behavior when the player exits its range.

Lastly, we should look at `Debug.Log()`. This function will print values to the console, whose tab is next to the Game view. Debug.Log is a powerful tool for figuring out what might be causing unexpected behavior in your game. Here, we'll just use it to print informational messages.

Once you have created your Goal script and added it to your trigger, you should now be able to see the messages you put in the Debug.Log for each trigger scenario when you check the Console tab. What you have now is the foundation for a maze game. Now that you know about colliders, you can build some walls that are both visible and invisible and create your own maze.

###Bonus round
If you have created your maze, you can let your classmates test it out. Move the Console tab to another pane so that you can see its messages while playing the game in the editor. Give each other feedback on the design choices of the maze. You must be able to solve your own maze before letting your classmates try it, so don't make it impossible!
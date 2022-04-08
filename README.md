# InnovamatTestUnityDev

>Unity 2019.4.15f1
>Standar 3D pipeline
>No special packages needed
>This game uses the old input system

To open the project, you can just clone the repo, and use Unity.
After, recompilation, you should be able to simply play the game.

Match-o, Match-o, Game!

Match-o, Match-o, Game! is a simple game of matching words with their correspondant cardinal.
For instance, Spanish word "Uno" with the cardinal "1".
You can miss two times, otherwise the system will compute an error.

You will find all scripts inside /assets/Scripts
The most important class is Controller.cs as this program follows a mediator pattern.

If you need to test classes, you can find Debugger.cs. You can call it during the game by pressing P on the keyboard.
I encourage you to implement your own tests.


Managing stages

Bear in mind that Controller lookup is done inside the Start() loop.
# OfficeCrawler
### Authors: Duncan Redheendran, Ryan O'Mullan, Ian Cullicott, Jax Gerlich
## Area of Study
We have been studying game development and design, using the Monogame Framework and C# as our language. Our game will be a rougelike dungeon crawler set in an office building, where you insult your coworkers until you reach the CEO.
## Progress
While it may look like we have lost progress, we have actually done a lot of work. We scrapped both our previous codebase and idea for another. In this idea, you will instead run around rooms of the office building "collecting your thoughts", in which you run over words in order to construct insults. You will then spit your insults at your coworkers in the usual Office Crawler style. Our code base has undergone significant changes as well. We have deleted our scrappy, hacky, original version and replaced it with a new, ECS based system. We took inspiration from Unity and our own ideas to make a custom ECS system, or Entity-Component System. Basically, we now have "Entitys", which will be a collection of "Components" which are collections of data, and in our case, behaviours. We have also extended the graphics system of Monogame to allow for drawing of primitives and have started on a new system for rendering to the screen with a 2D camera.
## Challenges
Our biggest challenge was starting from a blank slate. Because of the state of our hacky first approach, it was a necessary evil though. Getting past our first bad ideas into the real grit of our game was very difficult.
## Next Steps
Our next steps include finishing the backend of our game. Once we finish the rendering systems, and physics we can finish the prototype itself. With the better support for the game, instead of having to start over if we don't like the prototype, we can just take out the parts we like and use the skeleton to make another prototype.

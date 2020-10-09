# OfficeCrawler
### Authors: Duncan Redheendran, Ryan O'Mullan, Ian Cullicott, Jax Gerlich
## Area of Study
We have been studying game development and design, using the Monogame Framework and C# as our language. Our game will be a rougelike dungeon crawler set in an office building, where you insult your coworkers until you reach the CEO.
## Progress
We have been working on our gameplay prototype. So far we have made rendering, input, basic game states, the basic gameplay loop, enemies, and we have attempted some basic physics. Our grasp of the C# language has improved drastically, as well as our understanding of the Monogame Framework and structure of games. We understand that our codebase might be unreadable, but we are okay with that, as a complete rewrite is our next steps.
### Gameplay Gif!
![alt text](https://github.com/Pillber/OfficeCrawler/blob/develop/ezgif.com-gif-maker.gif)
## Significant Accomplishments
Our biggest accomplishment is a fully playable combat prototype of our game, which is the biggest aspect of our rougelike dungeon crawler.
## Biggest Challenge
Our biggest challenge was twofold. One, was NullPointerExceptions, which would freeze the development computer and require a hard restart. The other was physics collisions, which we didn't have enough time to fully implement.
## Timeline and Plan Changes
Our original timeline was very generous, as we severly underestimated the amount of work we had to do. We were able to add much more than we thought we would in our given time frame. Our plan for the rest of the year remains about the same.
## Next Steps
We have two options from here. We can either continue learning the language and framework with our gameplay prototype, or we can jump right into full game development. Continuing the gameplay prototype will include steps like physics collisions, tilemaps, obstacles, screen scrolling, more artwork, game states, more enemies, ect. Full game development will intail a full rewrite of the code to upgrade the codebase and allow modular development. Depending on feedback, we will choose our next steps.

## Running Yourself
If you are interested in running yourself, there are some steps to follow:
1. Install Visual Studio 2019 (any version, we use community) and add the following modules to the installation:
    * .NET Core cross-platform development
    * Mobile Development with .NET
    * Universal Windows Platform development
    * .NET desktop development
2. When the installation finishes, add the "Monogame project templates" extenstion and GitHub for Visual Studio to your installation.
3. Install the MGCB Editor (for managing the content of the game) by running the following commands in a command prompt:
    * `dotnet tool install --global dotnet-mgcb-editor`
    * `mgcb-editor --register`
4. Use GitHub to clone the repository to your local machine.
5. Debug the application by pressing the button in the toolbar or F5.

## To Play
**This game is not fully stable. It is not recommended to play this with unsaved files open, unless you like to live on the edge.**

Use ESDF to move. This control scheme is the same as WASD as E moves you up, S moves you right, etc. We feel like these controls allow for the ease of switching between moving and typing mode that WASD fails to provide. When the background is blue, you can move. If the background is red, you are in the insulting phase. Press enter to switch between moving and insulting. Just type any insult in the top right (keep in mind caps and spaces) when in the insulting phase to prepare your insult (the text will turn green), and press enter to switch back to moving. When moving, use IJKL to shoot the insult in the cardinal directions. Press space to restart if(when) you lose. ALT + F4 will stop the game. We know of a few bugs that we are working on fixing. Please, respond with any feedback! 

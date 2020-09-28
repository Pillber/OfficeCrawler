# OfficeCrawler
### Authors: Duncan Redheendran, Ryan O'Mullan, Ian Cullicott, Jax Gerlich
## Overall Topic
Game Development and Design using the Monogame Framework and our original idea of the game titled "Office Crawler".

## What Have We Been Up To?
We have been learning the syntax, keywords, and prefered schemes of C#. At the same time, we have been teaching ourselves the Monogame framework, and the API surrounding it. Specifics about what we have learned include the event system in C# and various Monogame-specific calls such as `_spriteBatch.Draw();`

## Challenges
We have encountered many challenges. The event system in particular was very difficult to wrap our heads around. We also kept running into NullPointerExceptions that would nesitate a hard restart of the main computer.

## Next Steps
We believe that our next steps should include more playtesting to make sure that our gameplay prototype is fully valid. After that, restructuring of code and other refactoring will need to be initiated. Our current codebase is horrible, but works. That should change next, if and only if, our gameplay is engaging enough.

## To Get The Latest Updates
This ensures you are on the most up-to-date version of our game
1. Open up your command prompt navigate to where you have saved the cloned repository
   * The default that Visual Studio 2019 saves imported git repositories is C:\Users\Your_User\source\repos\OfficeCrawler
2. Once you have navigated to the folder type `git checkout branch` where `branch` is the name of the branch where you want to receive updates
   * The master branch is the one we recommend updating, you would type `git checkout master`, but if you want the development branch just type `git checkout develop`
3. Once you are in the branch type `git pull origin branch` where `branch` is the name of the branch you want to update
4. You should now have the latest changes to our game

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
**DO NOT WORK ON ANYTHING IMPORTANT WHILE PLAYING THIS. AN ERROR THAT WE HAVE YET TO REPRODUCE AND FIX MAY FREEZE YOUR COMPUTER, REQUIRING A HARD RESTART. PLEASE SAVE ANYTHING IMPORTANT BEFORE PLAYING.**

Use WASD to move. When the background is blue, you can move. If the background is red, you are in the insulting phase. Press enter to switch between moving and insulting. Just type "no u" (keep in mind caps and spaces) when in the insulting phase to prepare your insult (the text will turn green), and press enter to switch back to moving. When moving, use IJKL to shoot the insult in the cardinal directions. Press space to restart if(when) you lose. ALT + F4 will stop the game. We know of a few bugs that we are working on fixing. Please, respond with any feedback! 

## Screenshots
![AltText](https://github.com/Pillber/OfficeCrawler/blob/master/OfficeCrawlerProgress1.png?raw=true "A screenshot of the gameplay")


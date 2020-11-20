# OfficeCrawler
### Authors: Duncan Redheendran, Ryan O'Mullan, Ian Cullicott, Jax Gerlich
## Area of Study
We have been studying game development and design, using the Monogame Framework and C# as our language. Our game will be a rougelike dungeon crawler set in an office building, where you insult your coworkers until you reach the CEO.
## Progress
Following the implementation of the new ECS system, we have started working on a pixel perfect rendering system. After many tries and lots of tears, we finally got it to work. Now, the sceen is rendered at the pixel level, and upscaled as much as possible. The game starts in fullscreen mode, but pressing space will switch to windowed and allow for the resizing of the window. The game will also pillarbox or letterbox (or both) depending on the size of the window and the virtual resolution. Be careful, as if you make the window too small, it will crash (divide by zero error, haven't fixed it yet). As a recap, the rendering system is now "pixel perfect", meaning that everything moves at the same pixel amounts.
## Screenshot!
![Our Progress So Far](https://github.com/Pillber/OfficeCrawler/blob/develop/OfficeCrawlerProgress3.png)
![Our Progress So Far](https://github.com/Pillber/OfficeCrawler/blob/develop/OfficeCrawlerProgress4.png)
Look! Different Resolutions! How cool!
## Challenges
The biggest challenge was fullscreening. We encountered lots of errors with stretching of the assets when in fullscreen. After much debugging, we fixed the problem by messing with the backbuffer settings. 
## Next Steps
Our next steps include finishing the backend of our game. Once we finish the rendering systems, and physics we can finish the prototype itself. With the better support for the game, instead of having to start over if we don't like the prototype, we can just take out the parts we like and use the skeleton to make another prototype.
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
There isn't much to play here... You can press WASD to move around, and that's about it. Most of our work is hidden behind the scenes this time. However, feel free to jam out around the red rectangle to the original music composed by Jax.

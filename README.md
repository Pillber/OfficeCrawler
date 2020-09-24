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

## Running Yourself
If you are interested in running yourself, there are some steps to follow:
1. Install Visual Studio 2019 (any version, we use community) and add the following modules to the installation:
    * .NET Core cross-platform development
    * Mobile Development with .NET
    * Universal Windows Platform development
    * .NET desktop development
2. When the installation finishes, add the "Monogame project templates" extenstion to Visual Studio.
3. Install the MGCB Editor (for managing the content of the game) by running the following commands in a command prompt:
    * ```dotnet tool install --global dotnet-mgcb-editor```
    * ```mgcb-editor --register```
4. Debug the application by pressing the button in the toolbar or F5.

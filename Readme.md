The Old World Bannerlord Mod

This is the main development branch.

What you need to make this work (build mod from source):

- Install Visual Studio 2019 Community Edition - it's free.
- Clone this repository to a local path
  - make sure it is somewhere far from Bannerlord's Module folder
- Open TOW_Core.csproj with a text editor
- Change the GameDir project property to point to your local Bannerlord path (Optional - only needed if your local Bannerlord installation is not in the default location)
- Open TOW_Core solution in Visual Studio
- Build the solution
  - this will create the necessary files and folders in your Bannerlord installation's Modules folder
- Get the Armory modules's AssetPackages directory from the shared drive and copy it to your Modules\TOW_Armory\ directory
- ???
- Profit.
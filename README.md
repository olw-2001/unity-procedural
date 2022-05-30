# Unity procedural game 

### **NOTE - A build of this game is missing from this repo. Trying to build results in a lot of ambiguous errors that I cannot fix in time. The game is still working, but there is no build version.**

Simple endless runner style game with procedural generation. The score increases the further you travel. If you hit an obstacle and bounce too high up, the game will restart - falling off the level will also fail you.

The game uses a custiomised Perlin noise generation system with values such as persistance, lacunarity, and octaves all working to create a complex noise map and, as a result, a complex level.

This system solves the problem of having to hand-build lots of levels, and instead it has a level generate randomly to maximise replayability.

## Areas of incompletion
The game initially intended to have an AI agent run through the level to validate the level is passable. This has not been implemented.

The map was intended to be infinite via a chunk system, but this was not implemented due to time. The levels are a fixed size.

The levels and their mesh colliders **do not re-generate in-game.** If you want to generate a new level, it has to be done in the editor, and the mesh collider component needs to be removed and added to reset the collision.

## Running the game
This project does not require much computational power, so the resources required should be very low. **The exact requirements are not known**

To see the source code, assets, and inspector changes, open the project with Unity 2021.3.1f1.
(This version of Unity was used to develop the game.)

## Gameplay and controls
A & D - move left and right

Get to the end of the level without falling off or bouncing too high from the level.

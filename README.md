# VectorProto
Vector graphics, rope physics, tiny little spaceships, basic 2 or 4 player multiplayer, and a Moba map layout.
Well, that's the plan anyway! Game prototype for [Day9's DK30 event](http://dk30.day9.tv/), for the November 13th to December 13th (Fall) session. [Project feed here](https://dk30.day9.tv/projects/342095521344913410-1541883495039?t=1541900694038).

------------

Goals for this prototype includes:

## Find a way to create attractive looking ~~vector-like~~ simple poly graphics.
Originally this game envisioned vector-like graphics (think Geometry Wars), however I've decided that considering the game is actually using 3D graphics, an actual vector-like would certainly look unique, but probably not *good*. So I've decided to go with a very clean, minimalist low-poly style. Triangular shapes, flat surfaces, simple shading - easy to do and looks good!


## Create some cool rope/chain physics
I've done this before in Love2D (Box2D physics):

![Rope Physics](https://thumbs.gfycat.com/SecretInsistentAnkole-size_restricted.gif)

(Better video: [Rope Physics](https://gfycat.com/SecretInsistentAnkole))

## Get some basic network multiplayer working

Absolute bare-bones, at the very least, get 2 players into a game to play against eachother. I've never done this before, so new stuff to be learned here!

## Finish with a playable game prototype

Obviously, that's the goal. This prototype should demonstrate how an actual game based on this would perhaps look, some general art style hints. It should demonstrate the physics system required to implement the core mechanic of the game (towing stuff around with your spaceship using a chain/rope). And, most importantly, it should demonstrate whether the core game loop is actually any fun or not!

-----------------

[**Prototype design document**](designdoc.md) is available for your perusal.

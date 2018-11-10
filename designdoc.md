# Vector (Simple MOBA-esque vector graphics thing)

---

Pitch:

You play as a small space ship, defending your side of the level by collecting resources, building defense structures using those resources, and then transporting those defenses to where you wish to place them on the map, by towing them there behind your little ship.

Core ideas:

- Retro "Asteroids"-like vector graphics style, but with more colors and some retromodern effects
- You control a very asteroids-like spaceship, just a simple shape with simple controls
- You play in a top-down view, on an arena-like level, in a team battle, red vs blue.
- There are resources on the map that players from any team can go pick up, and try to tow back home to base. If successful, the team (or the player?) earns resource points. Think Ore or Tiberium in C&C, just in bigger chunks that requires a player to dedicate a moment of their time to bring back to base.
- The resources can be spent by building a *"thing"*, like a defense tower, or a shield, etc. Once the construction is done (takes a dozen seconds or so), it spawns at your "factory".
- "Towing" mechanic: Players can shoot a string at objects in the game, and tow them around. This includes resources, defense towers, maybe even other players, maybe wreckages (player ship corpses), and so on.

Notes:

**Towing** is the central focus of the game. The idea is that players are going out there to collect resources, while avoiding (or pursuing!) combat with players of the opposite team. Towing resources back home rewards you with resource points, that you can then use to build useful items that then can be towed into place at the front line, or wherever you want them.

**Ships (Players)** are fairly weak by themselves, so although they can shoot (basically exactly like in the classic Asteroids game), it's generally a better idea to try grab resources, so that you can build things to help you. The player projectiles do knock objects around a little bit more though, so that it's a valid / interesting strategy to shoot someone just to knock them away a small distance and annoy them / hinder them from effectively gathering resources.

When players are destroyed, they leave a wreckage behind for a short-ish amount of time, that other players (friend OR foe!) can tow back to base for some bonus resource points!

**Bases** are basically just a big building on each team's side of the map, that has a large health pool. Whichever team destroys the opposing team's base first, wins.

# Extended ideas, for going past the prototyping stage:

Not sure if the view of the map should be static, i.e. all players can see the whole map, at all times, and everyone can see what everyone else is doing. This is not super uncommon for party-style games, and leads to complete fairness since, well, everyone is cheating equal amounts by looking at what everyone else is doing.

Alternatively, it could be somewhat zoomed in, so that a player has to actually move around a little bit to get an idea of what other players are doing. Essentially MOBA or Action RPG style map awareness. Though probably still a fairly zoomed out view, the point of the game is not to obscure what is happening elsewhere on the map - having awareness of what your teammates as well as your opponets are doing at all times, leads to frantic decision making, which is in line with the overall game idea. But, unless the maps are really tiny, going with a follow-camera centered on the player might make more sense, since the maps can be of more sensible size then.

There might be "creep" waves of numerous but weak NPC units that repeatedly spawn and try to make their way to the enemy base, and if they get there, attack it. This borrows even deeper from the MOBA architecture. These do add pressure to build and maintain some form of defense, and it does add incentive to disrupt the opposing team's defenses as well. Without the pressure from creep waves or something similar, it might feel like the best play is to just repeatedly tow laser turrets (or whatever) all the way down to the enemy base until whoever was the fastest eventually wins. That's boring and feels basically pointless to the player.

It might be valid to just *outright borrow the whole MOBA map concept*, and have top / mid / bottom lanes, that each have a few checkpoints ("turrets" in classical MOBA games) along the way. To keep it interesting though, the map layouts could be a lot more varied, as long as the distances and the resources are symmetrical, or, at least in some sense, balanced. Not all maps have to be perfectly balanced, looking at games like StarCraft for example, there are many examples of maps that are not perfectly symmetrical, yet the game is extremely competitive in nature.

These checkpoints may not be literally turrets, but it should be a major point of interest to defend on your side, and defeat on the opponent side, whether it's because they offer bonus resources (spawns in an area around it until destroyed?) or because it makes it difficult for the enemy, and / or their creep spawns, to pass the checkpoint safely.

Finally, if you really want to go completely overboard with the whole idea of just becoming a miniature MOBA, you could also have key locations that spawn or do something interesting on a fixed timer - something like spawning a powerup, or, in keeping with the core theme of this game, spawning some interesting object that either team can "claim" by being the first to tow it, and can then be towed back home or used. Maybe an extra big turret or defensive shield bubble generator or whatever! Or maybe just a giant hunk of resources that weighs a ton and requires 2 players to tow effectively (maybe possible to tow with 1 player, just painfully slowly).

An interesting and suitably thematic idea might be to make creep waves spawn based on the total amount of resources collected by the team over the course of the game. Maybe the spawn timer is reduced by 1% for every resource point or whatever, something like that. This makes resource gathering very powerful, since, eventually, even if the creep waves are weak, if there's one of them coming down the lane every 10 seconds, the defenders might be in serious trouble.

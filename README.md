# coffeerl
A simple roguelike project

## What's this?
An attempt at making a "coffeebreak" roguelike.  I want the game to be simple, easy to understand, and above all else easy to pick up and put down as needed. I love the genre, but often times what starts as a quick game of just clearing a few floors ends up as a mind-game of juggling gear, keeping track of many skills/classes/traits, many monster types, etc.  What if you just have ten minutes to kill while you're on break?  What if you're slogging through some code and need to un-cook your brain for a while?  That's the niche I intend to aim for.  The minimal number of stats, gear options, and monsters to make a game feel full and fun, without making it feel like you're splitting the atom.

## How did you make this?
It's all C# using the [RLNET](https://bitbucket.org/clarktravism/rlnet/) library.  Check it out, it's awesome.

## Where does it run?
It is tested and known to work on Windows, MacOS X (via Mono), and Linux (where it was developed, via Mono).  It may require you have various SDL libraries installed on Linux, like `sdl-image` and possibly others.  Let me know if you run into trouble using the issue tracker.

## So, is this a game or a framework?
It's a game.  I'm rolling my own engine/internals partially as an exercise and partially so I can keep things simplified.  I plan to have a simplified version of vision, for example.  There are great C# frameworks available that cover the nuts and bolts already.  If you're after a toolkit then these aren't the droids you're looking for.  (For now.  Maybe this'll change later.)

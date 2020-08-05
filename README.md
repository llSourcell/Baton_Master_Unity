# Baton_Master_Unity

![Image of Baton Master](https://i.imgur.com/ggxsA1g.png)

### Contributions are welcome! 

## Overview 

Baton Master is an educational Virtual Reality experience built for the Oculus platform. It allows a player to conduct an orchestra in a simulated environment. This is a project built using Unity, and the implementation files are in C#. Right now, the game is built around 1 song: "Finish the Fight" by Michael Salvatorri, aka the Halo 3 theme (because Halo 3 will always be my favorite Halo game, sorry kids). But more songs can easily be added once you understand the project structure and game mechanics. 

Watch the tutorial [here](https://youtu.be/tLZgW-R_Y7g). 

## Credits

Shoutout to the Unity team, the Oculus team, and [Calebsem](https://gist.github.com/Calebsem) for the metronome functionality example in C#. 

## Learning Resources Used

- [Valem's Youtube Channel](https://www.youtube.com/channel/UCPJlesN59MzHPPCp0Lg8sLw)

- [Unity's native tutorials](https://learn.unity.com/tutorials)

- [Reality is Broken by Jane McGonigal](https://www.audible.com/pd/Reality-Is-Broken-Audiobook/B004JOD9B0?site=3582&ref=101248&awc=14444_1596638562_11581eb41713443f479d55743ea359f5&source_code=AFNORBN1028159032)

- [Blood, Sweat, & Pixels by Jason Schrier](https://www.audiobooks.com/audiobook/blood-sweat-and-pixels-the-triumphant-turbulent-stories-behind-how-video-games-are-made/301216?refId=38712&gclid=CjwKCAjwsan5BRAOEiwALzomX8bvZ63bJer7qqOFOWNnmf6bAFJAKY4HYOQsl2SDsl_HUpJ6g-pB2RoC26IQAvD_BwE)

## Dependencies

- Download Unity
- Download Visual Studio
- Download the Oculus desktop app  (only necessary to play it in VR)
- Unity Store packages used: AurynSky (starfield skybox), Oculus Integration, Volumetric Lines, & Particle Ribbon.
- CGTrader assets used: Orchestra NPC collection, Concert Hall. 

## How to run 

- Open this project in Unity Hub, it's labeled "New Unity Project (1)". 
- Make sure Oculus desktop + the headset is connected to your computer.
- Hit compile and play!

I love using the Oculus Link beta. I've actually been coding with the headset on in Oculus Home and when i compile my code, my surrounding reality becomes my compiled game. It's a pretty amazing developer workflow. 

## Project Structure

#### Metronome.cs

- This is the metronome timer functionality. We initialize a metronome at 68 beats per minute, then in real-time track the direction that the player's right hand is moving. The way we track hand direction is to create 4 spheres next to the player, equidistant from each other. Then we compute how close the hand is to each sphere, and the closest sphere is the direction (i.e left, right, up, down). There's also functionality for vibrations, and updating the conducting visual (green to red). The score is being computed here too. 

#### Spawner.cs

- Spawner is an object that spawns hand-shaped assets and has them move towards you. This is similar to the beat saber mechanic. It's also got its own timer, and at the relevant time markers, it will send 'cues' towards the player, and the player then has to touch the cue to get the point. It will also display the crescendo indicator accordingly (raise hands). The score is also being computed here.

#### Cube.cs

- This is the hand-shaped object that the spawner spawns. It's just 1 line in the update function, move forward when instantiated. 

#### cueIntersection.cs


- This is the raycast functionality for the left hand. And invisible pointer is initialized from the left hand, and whenever that pointer intersects with an incoming cue marker, the player gets a point. Dual handed gaming FTW!


## TODOs 

- This game is based on 1 song, add more
- The orchestra is not moving, create an animation loop for the orchestra, treat it as a particle system.
- Use Deep Reinforcement Learning to create an adaptive animation loop, the orchestra plays louder, moves faster, as the player moves their hands.
- Make the failure mode more robust and fun. Have the song slowly break apart as failure nears.


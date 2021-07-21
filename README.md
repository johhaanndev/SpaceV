# SpaceV

Space V will be an arcade quick game that rocks at the beat of the music.

This game is in current development and will be updated by the time content is added. At the moment the game is in whitebox with only simple poligons.

## Game experience

Space V is about a collector space ship in the middle of an asteroid field. Player will have to collect as many collectables as he can and avoid all he flying asteroids.
These asteroids will spawn at the beat of the music, which means there are more than 1 type of asteroids.

(Further ideas/content might change the current game experience)

## Development

### Player control

Player only need the mouse in order to move the ship. Ship always faces where the cursor is and move towards it once the player clicks. User can also hold the mouse button and drag arround the screen, ship will follow with a little of delay to make it smoother.

### Spawn on the beat

As it was mentioned before, asteroids are spawning on the beat of the music. This is done in a script that detects the audio clip loudness called AudioFrecuency.cs

_AudioFrecuency.cs_

This class is the responsible for detecting the loudness.

We set an empty array and a maximum length, this array will contain the loudness values and will be updated every X time. When array is filled, then will calculate the average loudness value.

To make it visible and friendlier for the development, a circle will change its size according to the loudness.

(The script was extracted from this tutorial: https://www.youtube.com/watch?v=LlkdQSjXd_A&ab_channel=ecrax)

_Asteroid Spawners at the beat_

When playing, the level will spawn asteroids at the tempo of the song, differentiating kicks, claps even melody. But that can't be done only detecting the song audio clip, we would need some kind of equalizer to differentiate high, mid and low frecuencies. But there is an alternate way to separate the kicks from the claps, and that is by creating track channels.

It might look a rusty method but it is easy and quick, at least for now. Track channels are created with FL Studio software, it can be done with the free version. Loading the main audio and putting, for example the default kick audio sound, anywhere in the track. Like this: https://imgur.com/Eav4SUN

Render channel and after having all the channels rendered we get different audio sources: https://imgur.com/a/mAKi3yA

The song game object will have a children for each track channel, and loudness will be detected in each channel. This way, kicks and claps are separated from the melody and lyrics properly.


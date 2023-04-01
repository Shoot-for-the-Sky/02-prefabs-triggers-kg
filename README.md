# Prefabs Triggers Task 1 (Kfir Goldfarb)

- Develop on Unity Version: `2021.3.18f1 (lts)`
- Online Link Game at [itch.io]()

### Things I hage changed:

1. Add a player shield material that appears when player take a shield for 5 seconds, and the shield is faded each second (it's opacity alpha rate is changing).
    1. You can see the function `changeShieldAlpha` I've added [here](Assets/Scripts/3-collisions/ShieldThePlayer.cs)
    2. You can see the screen record: ![gif-1](Gifs/gif-1.gif)

2. Extra change I've done is to make the background moving while playing the game (infinitely)
    * You can see the new script [here](Assets/Scripts/5-shield-background/BackgroundMoverScript.cs)
<h1 align="center">Egg Game</h1>

<br>

<p align="center"><strong>A tilt-controlled jumper about an egg with a face, built in Unity.</strong></p>



<p align="center">
  <img src="./Assets/egg_game_menu.png" alt="Egg Game running on a real device with an unlocked skin and a coin pickup" height="500px">
  <img src="./Assets/egg_game_gameplay.png" alt="Egg Game gameplay showing the egg character, a jump-boosting shoe power-up, and a coin magnet" height="500px">
  
</p>

<br>

## What it is

My first larger project — basically Pou's jump minigame taken far more
seriously than it needed to be. Tilt the phone, the egg drifts left and
right, and you climb as high as you can before missing a platform. Built in
2022, entirely by hand, no AI in the loop — figuring out one obscure physics
bug back then could eat a whole afternoon.

It was live on Google Play for a while and later pulled as store policy
around ad SDKs and permissions moved on without it.

## Features

- **Tilt controls** — the accelerometer steers the character, no buttons
- **Screen wrapping** — cross one edge, appear on the other, keeps the climb going
- **Power-ups** — jump-boosting shoes, coin-attracting magnets
- **15 unlockable skins** via a mystery-box system
- **Local progression** — shop state and stats saved/loaded with `JsonUtility`
- **Rewarded ads** (AdMob) for extra coins or an extra life

## Tech stack

- **Unity** (2D)
- **C#**
- Unity's 2D physics + accelerometer input
- `JsonUtility` for local save/load
- Google Mobile Ads SDK (AdMob)
- TextMesh Pro, PlayerPrefs, Particle System

## Running it locally

Open the project folder in **Unity Hub**, then open
`Assets/Scenes/Game.unity` and hit Play. No build server, no env vars — the
AdMob SDK will just log test warnings without a real ad unit ID configured.

## License

No LICENSE file is committed to this repo. Shared for portfolio and viewing
purposes — add a LICENSE if you want the terms explicit.

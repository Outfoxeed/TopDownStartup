# Table Of Contents
- [Architecture](#architecture)
  - [Dependency Injection](#dependency-injection-zenject)
  - [ScriptableObject Architecture](#scriptableobject-architecture)
    - [Variables](#variables)
    - [Events](#events)
    - [Variable/Event Listener](#variableevent-listener)
  - [Multiple Scene Workflow](#multiple-scene-workflow)
  - [Tweakability](#tweakability)
    - ["MusketeerEvents"](#musketeerevents)
    - [AwakeCallback](#awakecallback)
    - [InputCallback](#inputcallback)
  - [Async](#async)
- [Design Patterns](#design-patterns)
  - [Object Pool](#object-pool)
  - [Observer](#observer)
  - [Factory](#factory)
  - [Commands (without undo)](#commands-without-undo)

# Architecture
## Dependency Injection (Zenject)
To inverse the dependencies to respect the SOLID principle, we chose to use Zenject for dependency injection in our project. 

## ScriptableObject Architecture
We chose to import [this package](https://github.com/DanielEverland/ScriptableObject-Architecture) based on the [Ryan Hipple's 2017 Unite talk ](https://www.youtube.com/watch?v=raQ3iHhE_Kk).
<br>
It allows us to have ScriptableObject containing an event or a variable. It uses the ScriptableObject as middle-mens between the systems using/modifying a value/event and the users of this value/event. 

The ScriptableObjects are injected into MonoBehaviour classes through inspector and into other classes through [Dependency Injection](#dependency-injection-zenject) 

### Variables
We are using Variable ScriptableObject to communicate values between scenes and easily debug the feature/mechanics using the variables
<br>
Ex: PlayerHealth (value set by Player's Health, used by Healthbar)
### Events
We are using Events ScriptableObject to communicate events between scenes and easily debug the feature/mechanics binded to some game events
<br>
Ex: PlayerDied (triggered by Player's Health, used by GameOver UI to enable itself)
### Variable/Event Listener
Linked with the [tweakability of the project](#tweakability-with-unityevents). The package comes with MonoBehaviour classes able to subscribe a UnityEvent to VariableScriptableObject or EventScriptableObject.  

## Multiple Scene workflow
We are using a multiple scene workflow for different reasons:
- Better system isolation: allows a faster dev/debugging of some systems (ex: UI)
  - Ex: We are able to test the UI without having to play the game (health bar, game over menu) thanks to [ScriptableObjectArchitecture](#scriptableobject-architecture)
- Less conflict on the version control as we're less modifying the same scenes

The boot scene is responsible for loading and unloading the wanted scenes at runtime.

## Tweakability
To offer a tweakabilty to GameDesigners. We created a few classes allowing a non-tech user to invoke UnityEvents at some events.
### "MusketeerEvents"
Wrapper class of a C# delegate and a UnityEvent. Used to have a UnityEvent and a classic C# event for a same event.
### AwakeCallback
MonoBehaviour class trigerring a UnityEvent at Awake
### InputCallback
MonoBehaviour class triggering a UnityEvent when an input from a given InputActionReference is performed

## Async
We are using async methods for different reasons:
- Shoot multiple projectiles with an interval instead of one projectile without pausing the shooting cooldown
- Wait the scenes unloading before re-loading the scenes for game restart
- Release projectiles into their pool after X seconds of life

# Design Patterns
## Object Pool
The game is using a lot of enemies and bullets.
To avoid lag spikes by creating/destroying elements continously in the gameplay. <br>
We are using ObjectPools for enemies, projectiles, particles.

## Observer 
We are using an observer pattern in the project.
<br>
For example, we have an IUpdateSystem on which other classes can subscribe to for having their Update method without being a MonoBehaviour class.

## Factory
In the project, we need to create guns with different behaviors at runtime. And so we are using a factory to handle the creation of the needed gun depending on some parameters we give to it.

## Commands (without undo)
For an easy [tweakability](#tweakability) of the level waves.
We are using a list of "WaveCommands" defined in a ScriptableObject.
<br>
The system responsible of spawning the waves queues the "WaveCommands" and wait for the current one to be finished to start the next one. 

There are the available WaveCommands:
- SpawnOneEnemy (waits for the spawned to be killed to be finished)
- SpawnEnemiesForDuration (spawns enemies at a variable rate for X seconds)
- ClearAllEnemies (kill all enemies)
- Wait (wait for X seconds)
- Combined (contains a list of WaveCommands and wait for all commands in its list to be finished to consider itself finished)
# Architecture
## Dependency Injection (Zenject)
To inverse the dependencies to respect the SOLID principle, we chose to use Zenject for dependency injection in our project. 

## ScriptableObject Architecture

### Variables
### Events

### Variable/Event Listener

## Multiple Scene workflow

## Tweakability with UnityEvents
### "MusketeerEvents"
### AwakeCallback

### InputCallback

## Async


# Design Patterns
## Object Pool
The game is using a lot of enemies and bullets.
To avoid lag spikes by creating/destroying elements continously in the gameplay, we are using ObjectPools.

They instantiate an amount of elements at start and reuse them when needed. It create new elements at runtime only if already exising instances are already used.

## Observer 

## Factory

## Commands (without undo)
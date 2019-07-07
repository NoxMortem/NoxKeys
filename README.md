# NoxKeys
Simple utiltiy scripts helpful to decouple key bindings from handling code.

# Features
* Decouples KeyBinding from calling code
* Provides interface for most common keys.
* Provides pattern for both key strokes (Down,Up,Held) or modifiers (any)

## Usage
* Define custom Bindings in `SmartKeys.Mapping.cs`, and handle whatever special cases required.
```
// 1. Define Mapping in SmartKeys.Mapping.cs
public static bool Screenshot(Functor check) => check.All.Key(KeyCode.F12);
// 2. Provide accessor in SmartKeys.Functor
public bool Screenshot => Check(Mapping.Screenshot);
// 3. Optionally provide Modifier Behaviour
public static bool Screenshot => Check(Mapping.Screenshot);
```
* Verify mappings via custom defined 
```
if(SmartKeys.GetUp.Screenshot)
```
* Verify single key strokes with `SmartKeys.GetX.Key(KeyCode.Y)`
```
if(SmartKeys.GetUp.Key(KeyCode.A))
```
# Installation
* Import the noxkeys-<version>.unitypackage
* Move the folder NoxKeys/* folder to a commonly used assembly
  * e.g. Plugins/* if you do not use assembly definitions

# Disclaimer
This project is intented for personal use only at the moment and is provided AS IS. Use it at your own risk.
If others find it helpful - great, if not fine.
# Edgeforce Unity Assignment

## Unity Version
Unity 2022.3.62f3

## About
This is a small VR interaction and inventory project made in Unity using C#.

The player can look at objects, pick them up, store them in the inventory and drop them back into the world.

## Features
- VR interaction
- Pickup UI
- Fixed inventory slots
- Gun and ammo items
- Ammo is stackable
- Gun is non-stackable
- Drop items from inventory
- Pistol firing
- XR Device Simulator for PC testing

## How to Run
1. Open the project in Unity.
2. Open the main scene.
3. Press Play.
4. Use the XR Device Simulator to test the project.

## Architecture
I separated the interaction, inventory and UI systems into different scripts.

Item information is stored using ScriptableObjects. Inventory changes are handled using events so the UI updates automatically.

## Design Decisions
I used separate systems so that new items can be added without changing the main inventory system.

## Limitations
This project is mainly made for the assignment and uses a small number of example items.

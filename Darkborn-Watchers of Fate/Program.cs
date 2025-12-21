/*
 * 
 * Main App Section; used to initialize the app
 * -
 * Here, we inititialize all objects from diffrent classes, and set them to the 
 * 
 */
using AppInitializer;
using util.RenderHelper;
using game.Weapon;
using game.Player;
using System.Diagnostics;
using System.Random;

// inherit objects

// Init primary app class, used for high-overview tasks, such as setting the apps title
App app = new App();
Console.Title = app.setTitle();

Console.SetWindowSize(200, 50);

RenderHelper renderHelper = new RenderHelper();
List<Weapon> OwnedWeapons = new List<Weapon>();


renderHelper.RenderCenteredText("Enter your name: ", 1, false);

string playername = "";
while (playername == "" || playername.Length == 0)
{
    playername = Console.ReadLine();
}

Player player = new Player(playername);
renderHelper.RenderHeaderText($"Welcome, {player.Name}!", false, false, true, -1, 1500, true);

Console.Clear();

Weapon StoneSword = new Weapon(Weapon.Rarity.COMMON, "Stone Sword", "A basic stone sword.", 2, 30, 5);

renderHelper.RenderLoadingScreen(2000, -5);
renderHelper.RenderCenteredText("Press any key to continue..", -4, false);

Console.ReadKey();
Console.Clear();

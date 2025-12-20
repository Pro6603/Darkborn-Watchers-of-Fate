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

// inherit objects

Console.SetWindowSize(251, 50);

RenderHelper renderHelper = new RenderHelper();
List<Weapon> OwnedWeapons = new List<Weapon>();


renderHelper.RenderCenteredText("Enter your Name: ", 1, false);

string playername = "";
while (playername == "" || playername.Length == 0)
{
    playername = Console.ReadLine();
}
Player player = new Player(playername);
renderHelper.RenderHeaderText($"Welcome, {player.Name}!", false, true, false, -10, 1500, true);

Weapon StoneSword = new Weapon(Weapon.Rarity.LEGENDARY, "Stone Sword", "A basic stone sword.", 2, 30, 5);

renderHelper.RenderLoadingScreen(2000);


App app = new App();

Console.Title = app.Title;

// nope, no exit!
Console.ReadKey();

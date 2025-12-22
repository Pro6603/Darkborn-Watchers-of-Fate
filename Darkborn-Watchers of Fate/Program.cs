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
using System.Diagnostics;

// inherit objects
// Init primary app class, used for high-overview tasks, such as setting the apps title
App app = new App();
Console.Title = app.setTitle();

Console.SetWindowSize(200, 50);

ItemCatalog itemcatalog = new ItemCatalog();
WeaponCatalog swordcatalog = new WeaponCatalog();
SpellCatalog spellcatalog = new SpellCatalog();

RenderHelper renderHelper = new RenderHelper();
Inventory inventory = new Inventory();
Random globalRandom = new Random();

renderHelper.RenderCenteredText("Enter your name: ", 1, false);

string playername = "";
while (playername == "" || playername.Length == 0)
{
    playername = Console.ReadLine();
}

Player player = new Player(playername);
renderHelper.RenderHeaderText($"Welcome, {player.Name}!", false, false, true, -1, 1500, true);

Console.Clear();

Weapon StoneSword = new Weapon(Weapon.Rarity.COMMON, "Stone Sword", "A basic stone sword.", 2, 0, 5, 50);

renderHelper.RenderLoadingScreen(2000, -5);
renderHelper.RenderCenteredText("Press any key to continue..", -4, false);

Console.ReadKey();
Console.Clear();

// test loop stuff


renderHelper.RenderStamina(player);
renderHelper.RenderHP(player);

// items needed to craft an DullKnife
inventory.AddItem(itemcatalog.ShortStick, 2);
inventory.AddItem(itemcatalog.IronOre, 4);
//

renderHelper.RenderDialogueTB("saint", "here ya go, take the sword. youll need it.", "[TAKE]", "", "", 1, true);

renderHelper.RenderWeaponContext(StoneSword);
renderHelper.RenderNewWeaponText(StoneSword);

renderHelper.RenderDialogueTB("saint", "wanna practice with it a little?", "Yea, sure!", "nah..", "", 1, true);
Console.Clear();
renderHelper.RenderCenteredText("Some time later..", 0, false);
Thread.Sleep(2500);
Console.Clear();
player.HP = (int)randomutil.random.NextInt64(3, 8);
player.STAMINA = (int)randomutil.random.NextInt64(16, 24);
renderHelper.RenderDialogueTB("you", "... this weakend me quite alot, do you have a healing potion?", "", "", "", 1, true);
renderHelper.RenderDialogueTB("saint", "here ya go mate, hope this helps you:", "Take Potion", "", "", 1, true);
player.HP = 100;


Console.ReadKey();
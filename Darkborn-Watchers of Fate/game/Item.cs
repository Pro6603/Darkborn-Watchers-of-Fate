using System;
using System.Collections.Generic;
using System.Text;

public class Item
{
    public int ID { get; }
    public string Name { get; }
    public string Description { get; }
    public string Icon { get; }

    public int Amount;

    public Item(int id, string name, string description, int amount, string icon)
    {
        ID = id;
        Name = name;
        Description = description;
        Amount = amount;
        Icon = icon;
    }

    public int getId()
    {
        return ID;
    }

    public string getName()
    {
        return Name;
    }

    public string getDescription()
    {
        return Description;
    }

    public string getIcon()
    {
        return Icon;
    }

    // item defenition 
    // USING ITEM DATABASE NOW OKI BYE
}

using System;
using UnityEngine;

public class Item
{
	public int ID { get; set; }
	public string Name { get; set; }
	public string Type { get; set; }
	public string SpriteID { get; set; }
	public Sprite Sprite { get; set; }
    public bool Stackable { get; set; }
	
	public Item()
	{
		this.ID = -1;
	}

	public Item (string name, int id=-1, string type="Debug", String spriteID="Debug", Sprite sprite=null, bool stackable=false)
	{
		this.ID = id;
		this.Name = name;
		this.SpriteID = spriteID;
		if(sprite == null)
		{
			Debug.Log("Item.cs|item(string name, int id=-1, string type='Debug', String spriteID='Debug', Sprite sprite=null)|spriteID: " + spriteID);
			sprite = SpritesLoader.SpriteList.Find(itemSprite => itemSprite.name == spriteID);
        }
		this.Sprite = sprite;
        this.Stackable = stackable;
	}
}

public class EquippableItem : Item
{
	public bool Equiptable;
	public EquippableItem (int id, string name, string type, string spriteID, Sprite sprite, bool equiptable = true) : base(name, id, type, spriteID, sprite)
	{
		this.Equiptable = equiptable;
	}
}

public class UsableItem : Item
{
	public bool Usable;
	public UsableItem(int id, string name, string type, string spriteID, Sprite sprite, bool usable = true) : base(name, id, type, spriteID, sprite)
	{
		this.Usable = usable;
	}
}

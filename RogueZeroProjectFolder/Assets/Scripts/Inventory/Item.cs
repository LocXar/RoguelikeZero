using System;
using UnityEngine;

public class Item
{
	public int ID { get; set; }
	public string Name { get; set; }
	public Sprite Sprite { get; set; }
	public Item (string name, int id=-1, Sprite sprite=null)
	{
		this.ID = id;
		this.Name = name;

		if(sprite == null)
		{
			Debug.Log("SpritePath: " + Application.dataPath + "/StreamingAssets/Debug.png");
			sprite = Resources.Load<Sprite>(Application.dataPath + "/StreamingAssets/Debug.png");
			
		}
		this.Sprite = sprite;
	}
}

public class EquippableItem : Item
{
	public bool Equiptable;
	public EquippableItem (int id, string name, Sprite sprite, bool equiptable = true) : base(name, id, sprite)
	{
		this.Equiptable = equiptable;
	}
}

public class UsableItem : Item
{
	public bool Usable;
	public UsableItem(int id, string name, Sprite sprite, bool usable = true) : base(name, id, sprite)
	{
		this.Usable = usable;
	}
}

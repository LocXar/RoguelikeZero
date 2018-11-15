using System;
using UnityEngine;

public class Weapon : EquippableItem
{
	public string Attack { get; set; }
	public Weapon (string title, string attack, int id=-1, Sprite sprite=null, bool equiptable=true) : base(id, title, sprite, equiptable)
	{
		this.Attack = attack;
	}
}
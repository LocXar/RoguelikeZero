using System;
using UnityEngine;

public class Weapon : EquippableItem
{
	public string Attack { get; set; }
	public Weapon (string name, string attack, int id=-1, string type="Debug", string spriteID="Debug", Sprite sprite=null, bool equiptable=true) : base(id, name, type, spriteID, sprite, equiptable)
	{
		this.Attack = attack;
	}
}
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {

	private List<Item> database = new List<Item>();

	void Start()
	{
		database = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json")); //D:/Unity Projects/RogueSharpTutorial/Assets

		database.ForEach(delegate(Item item) {
			if(item != null)
				Debug.Log(item.ID + " | " + item.Name);
		});
	}

	public Item GetItemByID(int id)
	{
		foreach(Item item in database)
		{
			Debug.Log("Item ID: " + item.ID);
			if(item.ID == id)
			{
				Debug.Log("Item " + item.ID + " | " + item.Name + " found!");
				return item;
			}
		}
		return null;
	}
}
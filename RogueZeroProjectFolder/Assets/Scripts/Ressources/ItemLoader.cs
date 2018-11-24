using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class ItemLoader : MonoBehaviour {

    public List<Item> ViewableItemList = new List<Item>();
    public static List<Item> ItemList = new List<Item>();
    public static ItemLoader itemLoader;

	void Awake()
	{
        itemLoader = this;
		ItemList = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));

		ItemList.ForEach(delegate(Item item) {
			if(item != null)
				Debug.Log(item.ID + " | " + item.Name);
		});
	}

	public Item GetItemByID(int id)
	{
		foreach(Item item in ItemList)
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
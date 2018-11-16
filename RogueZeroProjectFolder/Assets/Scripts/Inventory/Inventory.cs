using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDatabase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	public int maxItemSlots;
	void Start()
	{
		database = GetComponent<ItemDatabase>();

		maxItemSlots = 5;
		inventoryPanel = GameObject.Find("UIInventoryPanel");
		slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
		Debug.Log("Inventory.cs|Start()|inventoryPanel: " + (inventoryPanel!=null) + " | slotPanel: " + (slotPanel!=null) + " | database: " + (database!=null) + " | maxItemSlots: " + maxItemSlots);
		for(int i = 0; i < maxItemSlots; i++)
		{
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].transform.SetParent(slotPanel.transform);
		}
		AddItem(1);
		AddItem(2);
	}

	public void AddItem(int id)
	{
		Item itemToAdd = database.GetItemByID(id);
		Debug.Log("Inventory.cs|AddItem(int id)|itemToAdd: " + itemToAdd.ID + " | " + itemToAdd.Name);
		for(int i = 0; i < items.Count; i++)
		{
			if(items[i].ID == -1)
			{
				items.Add(itemToAdd);
				GameObject itemObj = Instantiate(inventoryItem);
				itemObj.transform.SetParent(slots[i].transform);
				GameObject itemText = itemObj.transform.Find("Text").gameObject;
				GameObject itemImage = itemObj.transform.Find("Image").gameObject;

				Debug.Log("Inventory.cs|AddItem(int id)|itemToAdd.Name: " + itemToAdd.Name);
				Text itemTextComp = (Text)itemText.GetComponent("Text");
				Debug.Log("Inventory.cs|AddItem(int id)|itemTextComp!=null: " + (itemTextComp!=null));
				itemTextComp.text = itemToAdd.Name;

				Debug.Log("Inventory.cs|AddItem(int id)|itemToAdd.SpriteID: " + itemToAdd.SpriteID);
				Image itemImageComp = (Image)itemImage.GetComponent("Image");
				Debug.Log("Inventory.cs|AddItem(int id)|itemImageComp!=null: " + (itemImageComp!=null));
				itemImageComp.sprite = Resources.Load<Sprite>("/Graphics/Sprites/Inventory/" + itemToAdd.Type + "/" + itemToAdd.SpriteID + ".png");							//IMG2Sprite.instance.LoadItemSprite(itemToAdd.Type, itemToAdd.SpriteID);     					Resources.Load<Sprite>("/Graphics/Sprites/Inventory/" + itemToAdd.Type + "/" + itemToAdd.SpriteID + ".png");      IMG2Sprite. itemToAdd.Sprite;   Resources.Load<Sprite>(Application.dataPath + "/Graphics/Sprites/Inventory/Weapons/" + itemToAdd.SpriteID + ".png");
				
				Debug.Log("Inventory.cs|AddItem(int id)|slots[i]: " + slots[i].ToString());
				break;
			}
		}
	}




	/*public Image[] itemImages = new Image[numItemSlots];
	public Item[] items = new Item[numItemSlots];

	public const int numItemSlots = 4;

	public void AddItem (Item itemToAdd)
	{
		for (int i = 0; i < items.Length; i++)
		{
			if (items [i] == null) {
				items [i] = itemToAdd;
				itemImages [i].sprite = itemToAdd.Sprite;
				itemImages [i].enabled = true;
				return;
			}
		}
	}

	public void RemoveItem (Item itemToRemove)
	{
		for (int i = 0; i < items.Length; i++)
		{
			if (items [i] == itemToRemove) {
				items [i] = null;
				itemImages [i].sprite = null;
				itemImages [i].enabled = false;
				return;
			}
		}
	} */
}

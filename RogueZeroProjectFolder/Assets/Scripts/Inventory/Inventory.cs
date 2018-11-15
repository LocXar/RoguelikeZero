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

		maxItemSlots = 20;
		inventoryPanel = GameObject.Find("UIInventoryPanel");
		slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
		Debug.Log("inventoryPanel: " + (inventoryPanel!=null) + " | slotPanel: " + (slotPanel!=null) + " | database: " + (database!=null));
		for(int i = 0; i < maxItemSlots; i++)
		{
			slots.Add(Instantiate(inventorySlot));
			slots[i].transform.SetParent(slotPanel.transform);
		}
		AddItem(0);
	}

	public void AddItem(int id)
	{
		Item itemToAdd = database.GetItemByID(id);
		Debug.Log("itemToAdd: " + (itemToAdd!=null));
		for(int i = 0; i < items.Count; i++)
		{
			if(items[i].ID == -1)
			{
				items[i] = itemToAdd;
				GameObject itemObj = Instantiate(inventoryItem);
				itemObj.transform.SetParent(slots[i].transform);
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

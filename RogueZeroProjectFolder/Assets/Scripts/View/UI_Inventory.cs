using UnityEngine;
using UnityEngine.UI;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using System.Collections.Generic;

namespace RogueSharpTutorial.View
{
    public class UI_Inventory : MonoBehaviour
    {

        GameObject inventoryPanel;
        GameObject slotPanel;
        ItemLoader database;
        public GameObject inventorySlot;
        public GameObject inventoryItem;

        public List<Item> items = new List<Item>();
        public List<GameObject> slots = new List<GameObject>();

        public int maxItemSlots;
        void Start()
        {
            database = ItemLoader.itemLoader;

            Debug.Log(GameObject.Find("UIInventoryPanel") != null);
            inventoryPanel = GameObject.Find("UIInventoryPanel");
            slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
            Debug.Log("Inventory.cs|Start()|inventoryPanel: " + (inventoryPanel != null) + " | slotPanel: " + (slotPanel != null) + " | database: " + (database != null) + " | maxItemSlots: " + maxItemSlots);
            for (int i = 0; i < maxItemSlots; i++)
            {
                items.Add(new Item());
                slots.Add(Instantiate(inventorySlot));
                slots[i].transform.SetParent(slotPanel.transform);
            }
            AddItem(1);
            AddItem(2);
            AddItem(2);
            AddItem(2);
        }

        /**
          * Takes the id if an Item and adds it to the Inventory.
          * @param id an integer ID of the Item to add.
          */
        public void AddItem(int id)
        {
            Item itemToAdd = database.GetItemByID(id);
            Debug.Log("Inventory.cs|AddItem(int id)|itemToAdd: " + itemToAdd.ID + " | " + itemToAdd.Name);

            if (itemToAdd.Stackable && DuplicateCheck(itemToAdd))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == id)
                    {
                        ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                        data.amount++;
                        data.transform.Find("Amount").GetComponent<Text>().text = data.amount.ToString();
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == -1)
                    {
                        items[i] = itemToAdd;
                        GameObject itemObj = Instantiate(inventoryItem);
                        //give the itemData the info which item is used.
                        itemObj.GetComponent<ItemData>().item = itemToAdd;
                        itemObj.transform.SetParent(slots[i].transform);

                        // Get ItemName
                        GameObject itemName = itemObj.transform.Find("Name").gameObject;
                        //Debug.Log("Inventory.cs|AddItem(int id)|itemToAdd.Name: " + itemToAdd.Name);
                        Text itemNameComp = itemName.GetComponent<Text>();
                        //Debug.Log("Inventory.cs|AddItem(int id)|itemTextComp!=null: " + (itemTextComp!=null));
                        itemNameComp.text = itemToAdd.Name;

                        // Get ItemImage
                        GameObject itemImage = itemObj.transform.Find("Image").gameObject;
                        //Debug.Log("Inventory.cs|AddItem(int id)|itemToAdd.SpriteID: " + itemToAdd.SpriteID);
                        Image itemImageComp = itemImage.GetComponent<Image>();
                        //Debug.Log("Inventory.cs|AddItem(int id)|itemImageComp!=null: " + (itemImageComp!=null));
                        itemImageComp.sprite = SpritesLoader.SpriteList.Find(sprite => sprite.name == items[i].SpriteID);

                        // Get ItemAmount
                        GameObject itemAmount = itemObj.transform.Find("Amount").gameObject;
                        //Debug.Log("Inventory.cs|AddItem(int id)|itemToAdd.Name: " + itemToAdd.Name);
                        Text itemAmountComp = itemAmount.GetComponent<Text>();
                        //Debug.Log("Inventory.cs|AddItem(int id)|itemTextComp!=null: " + (itemTextComp!=null));
                        itemAmountComp.text = "";

                        if (itemToAdd.Stackable)
                        {
                            ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                            data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                            data.amount++;
                        }

                        Debug.Log("Inventory.cs|AddItem(int id)|items[i].ID: " + items[i].ID + " | items.Name: " + items[i].Name + " wurde dem Inv hinzugefügt.");
                        break;
                    }
                }
            }
        }
        /**
          * Takes the id if an Item and adds it to the Inventory.
          * @param item An item to check the Inventory for.
          */
        public bool DuplicateCheck(Item item)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == item.ID)
                    return true;
            }
            return false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RogueSharpTutorial.Controller;
using RogueSharpTutorial.Utilities;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.View;

public class UIController : MonoBehaviour {

    //public static List<GameObject> UIElementList = new List<GameObject>();
    //public List<GameObject> ViewableUIElementList = new List<GameObject>();
    [SerializeField] public static UI_Inventory inventoryCanvas;
    [SerializeField] public static UI_Stats uiStats;
    [SerializeField] public static UI_Messages uiMessages;

    // Use this for initialization
    void Start () {
        inventoryCanvas = GetComponent<UI_Inventory>();
        uiStats = GetComponent<UI_Stats>();
        uiMessages = GetComponent<UI_Messages>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void ToggleInventoryVisibility()
    {
        CanvasGroup inventoryCG = inventoryCanvas.GetComponent<CanvasGroup>();
        if(inventoryCG.alpha == 1f)
        {
            inventoryCG.alpha = 0f;
        }
        else
        {
            inventoryCG.alpha = 1f;
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public int amount = 1;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem myItens{get; set;}

    public void OnPointerClick(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            if(Inventory.carriedItens == null){
                return;
            }

            setItem(Inventory.carriedItens);
        }
    }

    public void setItem(InventoryItem itens){
        
        Inventory.carriedItens = null;
        itens.activeSlot.myItens = null;

        myItens = itens;
        myItens.activeSlot = this;
        myItens.transform.SetParent(transform);
        myItens.canvasGroup.blocksRaycasts = true;

        //ToDo   
    }
}

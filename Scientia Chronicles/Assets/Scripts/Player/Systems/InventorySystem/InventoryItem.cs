using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    private Image itensIcon;
    public CanvasGroup  canvasGroup{get; private set;}
    public Itens myItens{get; set;}
    public InventorySlot activeSlot{get; set; }
    void awake(){
        canvasGroup = GetComponent<CanvasGroup>();
        itensIcon = GetComponent<Image>();
    }

    public void Initialize(Itens itens, InventorySlot parent){
        activeSlot = parent;
        activeSlot.myItens = this;
        myItens = itens;
        itensIcon.sprite = itens.Icon;
    }
    public void OnPointerClick(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            Inventory.Singleton.SetCarriedItens(this);
        }
    }   
}

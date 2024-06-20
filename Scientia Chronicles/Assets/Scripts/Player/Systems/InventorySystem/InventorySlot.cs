
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot
{
    public Itens itens;
    private int quantity;
    private Image slotImage;
    Image iconItem;
    
    public void addItens(Itens newItens, int amount)
    {
        iconItem.sprite = itens.sprite;

        if(isEmpty()){
            itens = newItens;
            quantity = amount;
        }
        else if (itens.id == newItens.id && itens.isStack == true)
        {
            itens = newItens;
            quantity = amount;
        }
        else
        {
            Debug.Log("Item Ñ estacavel!!!");
        }

    }

    public void removeItens(int amount)
    {
        if (itens != null)
        {
            quantity -= amount;
            if(quantity <= 0){
                itens = null;
                quantity = 0;
            }
        }
    }

    public bool isEmpty(){
        return itens == null;
    }
}

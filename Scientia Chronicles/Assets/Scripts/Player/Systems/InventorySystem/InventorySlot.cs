
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot
{
    public Itens itens;
    private int quantity;
    private Image slotImage;
    private Image iconItem;

    public void Initialize(Image slotImage, Image iconItem)
    {
        this.slotImage = slotImage;
        this.iconItem = iconItem;
        ClearSlot();
    }
    public void AddItens(Itens newItens, int amount)
    {
        if (isEmpty())
        {
            itens = newItens;
            quantity = amount;

            // Atribui o sprite do item ao ícone
            iconItem.sprite = newItens.sprite;
            iconItem.enabled = true;  // Habilita a exibição do ícone do item
            UpdateSlotVisuals();
        }
        else if (itens.id == newItens.id && itens.isStack)
        {
            quantity += amount;
            UpdateSlotVisuals();
        }
    }

    private void UpdateSlotVisuals()
    {
        if (isEmpty())
        {
            if (iconItem != null) iconItem.enabled = false;  // Desabilita o ícone quando o slot está vazio
        }
        else
        {
            if (iconItem != null) iconItem.enabled = true;   // Habilita o ícone quando o slot não está vazio
            iconItem.sprite = itens.sprite;     
            iconItem.color = Color.white;             // Atualiza o sprite do ícone com o item
        }
    }

    public void RemoveItens(int amount)
    {
        if (!isEmpty())
        {
            quantity -= amount;

            if (quantity <= 0)
            {
                ClearSlot();
            }
            else
            {
                UpdateSlotVisuals();
            }
        }
    }

    public bool isEmpty()
    {
        bool empty = itens == null;
        return empty;
    }

    private void ClearSlot()
    {
        itens = null;
        quantity = 0;
        UpdateSlotVisuals();
    }


    public int GetQuantity()
    {
        return quantity;
    }
}

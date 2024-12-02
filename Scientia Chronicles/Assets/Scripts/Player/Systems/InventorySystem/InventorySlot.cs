
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
            //corrigir o resgate da sprite do item
            iconItem.sprite = itens.sprite;
            UpdateSlotVisuals();
        }
        else if (itens.id == newItens.id && itens.isStack)
        {
            quantity += amount;
            UpdateSlotVisuals();
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
        return itens == null;
    }

    private void ClearSlot()
    {
        itens = null;
        quantity = 0;
        UpdateSlotVisuals();
    }

    private void UpdateSlotVisuals()
    {
        if (isEmpty())
        {
            if (iconItem != null) iconItem.enabled = false;
            if (iconItem != null) iconItem.sprite = null;
        }
        else
        {
            iconItem.enabled = true;
            iconItem.sprite = itens.sprite;
        }
    }

    public int GetQuantity()
    {
        return quantity;
    }
}

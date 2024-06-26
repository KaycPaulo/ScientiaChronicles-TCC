using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<InventorySlot> slots;
    public int maxSlots;
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public Text title;
    public Transform inventoryPainel;

    public bool isInventoryOpen = false;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
        title.enabled = false;
        InitializeSlots();
        CreateInventoryUI();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInventoryOpen == false)
        {
            ToggleInventory();
            
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isInventoryOpen == true)
        {
            ToggleInventory();
        }

        // if (Input.GetKeyDown(KeyCode.E) && isInventoryOpen == false){
        //     isInventoryOpen = true;
        //     ToggleInventory(isInventoryOpen);
        // }

        // if(Input.GetKeyDown(KeyCode.Escape) && inventoryPanel == true){
        //     isInventoryOpen = false;
        //     ToggleInventory(isInventoryOpen);
        // }
    }

    private void InitializeSlots()
    {
        slots = new List<InventorySlot>(maxSlots);
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    private void CreateInventoryUI()
    {
        slots = new List<InventorySlot>(maxSlots);

        for (int i = 0; i < maxSlots; i++)
        {
            GameObject slotGo = Instantiate(slotPrefab, inventoryPainel);
            Image slotImage = slotGo.GetComponent<Image>();

            slotImage = null;
        }
    }

    private void ToggleInventory()
    {
        title.enabled = !title.enabled;
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
    }

    public void addItensInventory(Itens itens, int amount)
    {

        foreach (InventorySlot slot in slots)
        {
            if (slot.itens != null)
            {
                slot.addItens(itens, amount);
            }
        }
    }

}
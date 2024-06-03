using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public bool isInventoryOpen = false;

    private void Awake(){
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
                
        if (Input.GetKeyDown(KeyCode.E) && isInventoryOpen == false){
            isInventoryOpen = true;
            ToggleInventory(isInventoryOpen);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && inventoryPanel == true){
            isInventoryOpen = false;
            ToggleInventory(isInventoryOpen);
        }
    }

    private void ToggleInventory(bool state){
        inventoryPanel.SetActive(state);
    }
}
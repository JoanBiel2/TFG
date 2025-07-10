using UnityEngine;
using UnityEngine.InputSystem;


public class InventoryManager : MonoBehaviour
{

    private PlayerControls playercon;
    private InputAction menu;
    public ItemSlot[] itemslot;

    [SerializeField] private GameObject InvUI;
    [SerializeField] private bool IsActive;

    void Awake()
    {
        playercon = new PlayerControls();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        menu = playercon.UI.Inventory;
        menu.Enable();

        menu.performed += Inventory;
    }
    private void OnDisable()
    {
        menu.Disable();
    }
    void Inventory(InputAction.CallbackContext ctx)
    {
        IsActive = !IsActive;

        if (IsActive)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }
    void ActivateMenu()
    {
        InvUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        InvUI.SetActive(false);
        IsActive = false;
    }
    public void AddItem(string name, int quant, Mesh mesh, Sprite sprite)
    {
        for (int i = 0; i < itemslot.Length; i++)
        {
            if (itemslot[i].isFull == false)
            {
                itemslot[i].AddItem(name, mesh, sprite);
                return;
            }
        }
    }
}

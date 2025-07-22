using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{

    private PlayerControls playercon;
    private InputAction menu;
    public ItemSlot[] itemslot;

    [SerializeField] private PlayerInput pi;
    [SerializeField] private GameObject InvUI;
    [SerializeField] private bool IsActive;


    void Awake()
    {
        playercon = new PlayerControls();
    }
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
            pi.SwitchCurrentActionMap("UI");
        }
        else
        {
            DeactivateMenu();
            pi.SwitchCurrentActionMap("Player");
        }
    }

    void ActivateMenu()
    {
        Button button = itemslot[1].GetComponentInChildren<Button>(); //El 1 y el 0 estan visualmente cambiados. Si no se hace asi, hay un fallo que hace que no deje acceder
                                                                      //al primer item slot con el mando o el teclado
        InvUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(button.gameObject);
    }

    public void DeactivateMenu()
    {
        InvUI.SetActive(false);
        IsActive = false;
    }

    public void AddItem(string name, int quant, Sprite sprite, string desc)
    {
        for (int i = 0; i < itemslot.Length; i++)
        {
            if (itemslot[i].isFull == false)
            {
                itemslot[i].AddItem(name, sprite, desc);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemslot.Length; i++)
        {
            itemslot[i].selectedShader.SetActive(false);
            itemslot[i].itemSelected = false;
        }
    }
}

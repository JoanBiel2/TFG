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

    [SerializeField] private GameObject menuUI; //Tiene de hijos a inv y state
    [SerializeField] private GameObject invUI;
    [SerializeField] private GameObject stateUI;

    private bool isactive;


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
    private void Inventory(InputAction.CallbackContext ctx)
    {
        isactive = !isactive;

        if (isactive)
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

    public void ActivateMenu() //Tambien sirve como metodo para el botón de Inventory
    {
        Button button = itemslot[1].GetComponentInChildren<Button>(); //El 1 y el 0 estan visualmente cambiados. Si no se hace asi, hay un fallo que hace que no deje acceder
                                                                      //al primer item slot con el mando o el teclado
        menuUI.SetActive(true); //Aqui estan los botones para moverse por el UI
        stateUI.SetActive(false);
        invUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(button.gameObject);
    }

    public void DeactivateMenu()
    {
        menuUI.SetActive(false);
        isactive = false;
    }
    
    public void ButtonState()
    {
        stateUI.SetActive(true);
        invUI.SetActive(false);
    }

    public void AddItem(string name, Sprite sprite, string desc)
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

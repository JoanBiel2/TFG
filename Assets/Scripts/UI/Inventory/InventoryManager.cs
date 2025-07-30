using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


public class InventoryManager : MonoBehaviour
{

    private PlayerControls playercon;
    private InputAction menu;
    public ItemSlot[] itemslot;

    [SerializeField] private PlayerInput pi;

    [SerializeField] private GameObject menuUI; //Tiene de hijos a inv y state
    [SerializeField] private GameObject invUI;
    [SerializeField] private GameObject stateUI;

    //Pop-up de el objeto recogido del suelo
    [SerializeField] private Image popup;
    [SerializeField] private TextMeshProUGUI textevidence;
    [SerializeField] private Image imageevidence;
    public float fade = 3f;

    private Dialogue dialogue;

    private bool isactive;


    void Awake()
    {
        playercon = new PlayerControls();
        dialogue = GameObject.Find("DialogueManager").GetComponent<Dialogue>();
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
            if (dialogue.IsActive()) //Que barbaridad de codigo. Este if me ha solucionado dos problemas gordisimos
            {
                pi.SwitchCurrentActionMap("DialogueControl");
            }

            else 
            {
                pi.SwitchCurrentActionMap("Player");
            }
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

    public void AddItemInk(string name, string spritename, string desc)
    {
        Sprite sprite = Resources.Load<Sprite>($"Sprites/Evidences/{spritename}");
        Debug.Log(sprite.name);
        AddItem(name, sprite, desc);
    }
    public void AddItem(string name, Sprite sprite, string desc)
    {
        StartCoroutine(FadeOut());
        textevidence.text = name;
        imageevidence.sprite = sprite;
        for (int i = 0; i < itemslot.Length; i++)
        {
            if (itemslot[i].isFull == false)
            {
                itemslot[i].AddItem(name, sprite, desc);
                return;
            }
        }
    }
    private System.Collections.IEnumerator FadeOut()
    {
        float waittime = 1f;
        float elapsed = 0f;

        // Asegurarse de que el popup es totalmente visible al principio
        popup.color = new Color(popup.color.r, popup.color.g, popup.color.b, 0.8f);
        textevidence.color = new Color(textevidence.color.r, textevidence.color.g, textevidence.color.b, 0.8f);
        imageevidence.color = new Color(imageevidence.color.r, imageevidence.color.g, imageevidence.color.b, 0.8f);
        popup.raycastTarget = true;

        // Espera antes de comenzar el fade
        yield return new WaitForSeconds(waittime);

        Color startPanelColor = popup.color;
        Color startTextColor = textevidence.color;
        Color startImageColor = imageevidence.color;

        // Iniciar el fade-out
        while (elapsed < fade)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0.8f, 0f, elapsed / fade);

            popup.color = new Color(startPanelColor.r, startPanelColor.g, startPanelColor.b, alpha);
            textevidence.color = new Color(startTextColor.r, startTextColor.g, startTextColor.b, alpha);
            imageevidence.color = new Color(startImageColor.r, startImageColor.g, startImageColor.b, alpha);

            yield return null;
        }

        // Asegurar que todo queda en alpha 0
        popup.color = new Color(startPanelColor.r, startPanelColor.g, startPanelColor.b, 0f);
        textevidence.color = new Color(startTextColor.r, startTextColor.g, startTextColor.b, 0f);
        imageevidence.color = new Color(startImageColor.r, startImageColor.g, startImageColor.b, 0f);

        popup.raycastTarget = false;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemslot.Length; i++)
        {
            itemslot[i].selectedShader.SetActive(false);
            itemslot[i].itemSelected = false;
        }
    }
    public bool SearchEvidence(string name)
    {
        bool found;
        Debug.Log(name);
        ItemSlot result = Array.Find(itemslot, slot => slot.itemname == name);
        if (result == null)
        {
            found = false;
        }
        else
        {
            found = true;
        }
        return found;
    }
}

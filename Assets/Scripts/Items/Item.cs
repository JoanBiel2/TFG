using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Item : MonoBehaviour
{
    [SerializeField] private string evidencename; //Nombre del objeto
    [SerializeField] private int quantity; //No se usa
    [SerializeField] private Sprite sprite; //Como se ve en el inventario
    [TextArea][SerializeField] private string desc; //Descripción del objeto

    [SerializeField] private Renderer prompt; // Renderer del objeto visual
    [SerializeField] private Material keyboardMaterial;
    [SerializeField] private Material gamepadMaterial;

    private InventoryManager inventorymanager;
    private PlayerInput pi; //Para recoger pruebas con un botón

    private bool playernear;

    private System.IDisposable listener;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        inventorymanager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); //Recupera el script de InventoryManager
        pi = GameObject.Find("Player").GetComponentInChildren<PlayerInput>();
        playernear = false;
        prompt.gameObject.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        if (playernear && pi.actions["Interact"].IsPressed()) //Cuando el personaje este en el area de colision, deberia de recoger el objeto pulsando la E.
            {
                inventorymanager.AddItem(evidencename, quantity, sprite, desc);
                Destroy(gameObject);     
            }
    }

    private void OnTriggerEnter(Collider collision)
    //Hacer que aparezca un panel donde indique cuando se puede recoger el objeto
    {
        if (collision.gameObject.tag == "Player")
        {
            playernear = true;
            prompt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playernear = false;
            prompt.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        listener = InputSystem.onAnyButtonPress.Call(OnAnyInput);
    }

    private void OnDisable()
    {
        listener?.Dispose();
    }
    void OnAnyInput(InputControl control)
    {
        var device = control.device;
        if (device is Gamepad)
        {
            prompt.material = gamepadMaterial;
        }
        else if(device is Keyboard || device is Mouse)
        {
            prompt.material = keyboardMaterial;
        }
    }

}

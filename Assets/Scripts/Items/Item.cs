using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Item : MonoBehaviour, DataPersistance
{
    /// <summary>
    /// Cada prueba es unica y no debería repetirse ninguno de sus atributos
    /// </summary>

    private bool evidencegrab = false; //Contenido del diccionario
    [SerializeField] private string evidencename; //Nombre del objeto. Sirve como codigo del diccionario de GameData.
    [SerializeField] private Sprite sprite; //Como se ve en el inventario
    [TextArea][SerializeField] private string desc; //Descripción del objeto

    [SerializeField] private Renderer prompt; // Renderer del objeto visual
    [SerializeField] private Material keyboardMaterial;
    [SerializeField] private Material gamepadMaterial;
    [SerializeField] private int xpgiven; //Cada prueba da una cantidad de experiencia, la cantidad depende de la inportacia que tenga
    
    private InventoryManager inventorymanager;
    private CharacterInformation charinfo;
    private PlayerInput pi; //Para recoger pruebas con un botón

    private bool playernear;

    private System.IDisposable listener;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventorymanager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>(); //Recupera el script de InventoryManager
        pi = GameObject.Find("Player").GetComponentInChildren<PlayerInput>();
        charinfo = GameObject.Find("InventoryManager").GetComponent<CharacterInformation>();
        playernear = false;
        prompt.gameObject.SetActive(false);
        prompt.transform.localPosition = new Vector3(0, 2f, 0);
    }
    // Update is called once per frame
    private void Update()
    {
        if (playernear && pi.actions["Interact"].IsPressed()) //Cuando el personaje este en el area de colision, deberia de recoger el objeto pulsando la E.
        {
            evidencegrab = true;
            inventorymanager.AddItem(evidencename, sprite, desc);
            charinfo.AddExpItem(xpgiven);

            DataManager.instance.SaveGame();
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
        listener.Dispose();
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

    public void LoadData(GameData data)
    {
        if (data.evidencedic != null && data.evidencedic.TryGetValue(evidencename, out evidencegrab))
        {
            if (evidencegrab)
            {
                gameObject.SetActive(false);
            }
        }
    }


    public void SaveData(ref GameData data)
    {
        if (data.evidencedic.ContainsKey(evidencename))
        {
            data.evidencedic.Remove(evidencename);
        }
        data.evidencedic.Add(evidencename, evidencegrab);
    }
}

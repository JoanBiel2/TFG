using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class NPCInteract : MonoBehaviour
{
    private PlayerInput pi;
    private bool playernear = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pi = GameObject.Find("Player").GetComponentInChildren<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playernear && pi.actions["Interact"].IsPressed()) //Cuando el personaje este en el area de colision, deberia de hablar con el NPC
        {
            Debug.Log("KArballo"); 
        }
    }
    private void OnTriggerEnter(Collider collision)
    //Hacer que aparezca un panel donde indique cuando se puede recoger el objeto
    {
        if (collision.gameObject.tag == "Player")
        {
            playernear = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playernear = false;
        }
    }
}

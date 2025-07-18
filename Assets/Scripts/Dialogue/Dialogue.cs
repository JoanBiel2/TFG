using Ink.Runtime;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textcomponent;
    public TextMeshProUGUI namecomponent;
    private DialogueNode[] dialogueTree;
    public float textSpeed;

    private PlayerInput pi;

    private int mapindex; //Indice del mapa
    private int index; //Subvectoe de dialogos

    private float lastAdvanceTime = 0f;
    private float advanceDelay = 0.2f;

    private Story currentstory;
    private bool dialogueplaying;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetPlayerInput();
        mapindex = 0;
        dialogueplaying = false;
    }
    private void Update()
    {
        if (!dialogueplaying)
        {
            return;
        }
        else
        {
            if (TryGetPlayerInput() && pi.actions["Interact"].IsPressed())
            {
              ContinueStory();
            }
        }
    }

    private void ContinueStory()
    {
        if (currentstory.canContinue)
        {
            textcomponent.text = currentstory.Continue(); //Muestra la linea actual, y hace un indice++
        }
        else
        {
            ExitDialogueMod();
        }
    }

    // Método para obtener PlayerInput. Necesario para que no de error al cambiar de Action Map
    private bool TryGetPlayerInput()
    {
        if (pi == null)
        {
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                pi = player.GetComponentInChildren<PlayerInput>();
            }
        }
        return pi != null;
    }
    public void EnterDialoguemod(TextAsset InkJSON)
    {
        currentstory = new Story(InkJSON.text);
        dialogueplaying = true;
        gameObject.SetActive(true);

        ContinueStory();
        StartCoroutine(TypeLine());

        if (TryGetPlayerInput())
        {
            pi.SwitchCurrentActionMap("DialogueControl");
        }
    }
    private void ExitDialogueMod()
    {
        dialogueplaying = false;
        gameObject.SetActive(false);
        textcomponent.text = "";
    }
    //Avanzar el dialogo con el click izquierdo (El botón de Next se hace desde los eventos en el inspector)
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleAdvance();
        }
    }

    public void StartDialogueFromNPC(DialogueNode[] newlines)
    {
        textcomponent.text = string.Empty;
        namecomponent.text = string.Empty;
        dialogueTree = newlines;
        index = 0;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());

        // Verificar PlayerInput abans de cambiar el ActionMap
        if (TryGetPlayerInput())
        {
            pi.SwitchCurrentActionMap("DialogueControl");
        }
    }

    IEnumerator TypeLine()
    {
        namecomponent.text = dialogueTree[mapindex].dialogueline[index].speakerName;
        foreach (char c in dialogueTree[mapindex].dialogueline[index].text.ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < dialogueTree[mapindex].dialogueline.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            namecomponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (mapindex < dialogueTree.Length - 1)
            {
                mapindex++;
                index = 0;
                textcomponent.text = string.Empty;
                namecomponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);
                pi.SwitchCurrentActionMap("Player");
            }
        }
    }
    public void HandleAdvance()
    {
        if (Time.time - lastAdvanceTime < advanceDelay)
            return;

        lastAdvanceTime = Time.time;

        if (textcomponent.text == dialogueTree[mapindex].dialogueline[index].text) //Cuando el texto se completa, ya sea porque el jugador le ha dado al botón o por que ha pasado el tiempo
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textcomponent.text = dialogueTree[mapindex].dialogueline[index].text;
            namecomponent.text = dialogueTree[mapindex].dialogueline[index].speakerName;
        }
    }
}
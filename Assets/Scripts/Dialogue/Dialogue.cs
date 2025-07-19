using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    private static Dialogue instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguepanel;
    [SerializeField] private TextMeshProUGUI textcomponent;
    [SerializeField] private TextMeshProUGUI namecomponent;
    [SerializeField] private float textSpeed;

    private PlayerInput pi;

    private float lastAdvanceTime = 0f;
    private float advanceDelay = 0.2f;

    private Story currentstory;
    private bool dialogueplaying;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicestext;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Existe mas de un dialogue en la escena");
        }
        instance = this;
    }
    public static Dialogue GetInstance()
    {
        return instance;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetPlayerInput();
        dialogueplaying = false;

        choicestext = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicestext[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void Update()
    {
        if (!dialogueplaying)
        {
            return;
        }
        else
        {
            if (pi.actions["Next"].WasPressedThisFrame()) //TryGetPlayerInput() && 
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
            DisplayChoices();
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
        dialoguepanel.SetActive(true);

        ContinueStory();
        //StartCoroutine(TypeLine());

        if (TryGetPlayerInput())
        {
            pi.SwitchCurrentActionMap("DialogueControl");
        }
    }
    private void ExitDialogueMod()
    {
        dialogueplaying = false;
        dialoguepanel.SetActive(false);
        textcomponent.text = "";
        pi.SwitchCurrentActionMap("Player");
    }
    //Avanzar el dialogo con el click izquierdo (El botón de Next se hace desde los eventos en el inspector)
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("AAAAAAA");
            ContinueStory();
        }
    }
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentstory.currentChoices;
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("Demasiadas opciones");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicestext[index].text = choice.text;
            index++;
        }
        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectedFirstChoice());
    }
    private IEnumerator SelectedFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceindex)
    {
        currentstory.ChooseChoiceIndex(choiceindex);
        ContinueStory();
    }

    /*public void StartDialogueFromNPC(DialogueNode[] newlines)
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
    }*/

    /*IEnumerator TypeLine()
    {
        namecomponent.text = dialogueTree[mapindex].dialogueline[index].speakerName;
        foreach (char c in dialogueTree[mapindex].dialogueline[index].text.ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }*/
    /*void NextLine()
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
    }*/
    /*public void HandleAdvance()
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
    }*/
}
using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    private static Dialogue instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguepanel;
    [SerializeField] private TextMeshProUGUI textcomponent;
    [SerializeField] private TextMeshProUGUI namecomponent;
    [SerializeField] private Animator potraitanim;
    [SerializeField] private float textSpeed;
    private Coroutine showlinecor;
    private bool cancontinue = false;
    private bool inputBlocked = false;


    private PlayerInput pi;
    private Story currentstory;
    private bool dialogueplaying;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicestext;

    private const string SPEAKER_TAG = "Speaker";
    private const string PORTRAIT_TAG = "Portrait";

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
        if (!dialogueplaying || inputBlocked)
            return;

        if (!TryGetPlayerInput())
            return;

        if (cancontinue && currentstory.currentChoices.Count > 0)
        {
            if (pi.actions["Next"].WasPressedThisFrame())
            {
                GameObject selected = EventSystem.current.currentSelectedGameObject;
                for (int i = 0; i < choices.Length; i++)
                {
                    if (choices[i].gameObject == selected)
                    {
                        MakeChoice(i);
                        return;
                    }
                }
                MakeChoice(0);
            }
        }
        else if (cancontinue && pi.actions["Next"].WasPressedThisFrame())
        {
            ContinueStory();
        }
    }

    private void ContinueStory()
    {
        if (currentstory.canContinue)
        {
            if (showlinecor != null)
            {
                StopCoroutine(showlinecor);
            }
            showlinecor = StartCoroutine(ShowLine(currentstory.Continue())); //Muestra la linea actual, y hace un indice++
            HandleTags(currentstory.currentTags);
        }
        else
        {
            ExitDialogueMod();
        }
    }
    private IEnumerator ShowLine(string line)
    {
        textcomponent.text = "";
        yield return new WaitForSeconds(0.15f); //Para que no salte directamente a la siguiente linea de dialogo
        cancontinue = false;
        Hidechoices();
        foreach (var letter in line.ToCharArray())
        {
            if (pi.actions["Next"].IsPressed())
            {
                textcomponent.text = line;
                break;
            }
            textcomponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        DisplayChoices();
        cancontinue = true;
    }
    private void HandleTags(List<string> tags)
    {
        foreach (var tag in tags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("La has cagado en alguna tag");
            }
            string tagKey = splitTag[0].Trim(); //Quita los possibles espacios en blanco
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    namecomponent.text = tagValue;
                    break;

                case PORTRAIT_TAG:
                    potraitanim.Play(tagValue);
                    break;
            }
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
    public void OnPointerClick(PointerEventData eventData) //Ha dejado de funcionar por el Ink, hay que arreglarlo
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
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
    private void Hidechoices()
    {
        foreach (GameObject choicebutton in choices)
        {
            choicebutton.SetActive(false);
        }
    }
    private IEnumerator SelectedFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceindex)
    {
        if (cancontinue)
        {
            StartCoroutine(DelayText(choiceindex));
        }
    }

    private IEnumerator DelayText(int choiceindex)
    {
        inputBlocked = true;

        currentstory.ChooseChoiceIndex(choiceindex);

        // Espera hasta que el jugador suelte el botón "Next"
        yield return new WaitUntil(() => !pi.actions["Next"].IsPressed());

        ContinueStory();

        inputBlocked = false;
    }


}
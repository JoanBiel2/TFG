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
    private DialogueLine[] dialogueLines;
    public float textSpeed;

    private PlayerInput pi;

    private int index;

    private float lastAdvanceTime = 0f;
    private float advanceDelay = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetPlayerInput();
    }

    // Método para obtener PlayerInput de forma segura
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

    //Avanzar el dialogo con el click izquierdo (El botón de Next se hace desde los eventos en el inspector)
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleAdvance();
        }
    }

    public void StartDialogueFromNPC(DialogueLine[] newlines)
    {
        textcomponent.text = string.Empty;
        namecomponent.text = string.Empty;
        dialogueLines = newlines;
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
        namecomponent.text = dialogueLines[index].speakerName;
        foreach (char c in dialogueLines[index].text.ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
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
    public void HandleAdvance()
    {
        if (Time.time - lastAdvanceTime < advanceDelay)
            return;

        lastAdvanceTime = Time.time;

        if (textcomponent.text == dialogueLines[index].text)
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textcomponent.text = dialogueLines[index].text;
            namecomponent.text = dialogueLines[index].speakerName;
        }
    }
}
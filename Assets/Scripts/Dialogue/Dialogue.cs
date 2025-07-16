using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textcomponent;
    public string[] lines; //Hay que sacarlo del NPC
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleAdvance();
        }
    }

    public void StartDialogueFromNPC(string[] newLines)
    {
        textcomponent.text = string.Empty;
        lines = newLines;
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
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
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

        if (textcomponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textcomponent.text = lines[index];
        }
    }
}
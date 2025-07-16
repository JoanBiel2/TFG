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
        pi = GameObject.Find("Player").GetComponentInChildren<PlayerInput>();
    }
    //Se llama cada vez que se da click al ratón
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            HandleAdvance();
        }
    }

    public void StartDialogueFromNPC(string[] newLines)
    {
        lines = newLines;
        textcomponent.text = string.Empty;
        index = 0;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
        pi.SwitchCurrentActionMap("DialogueControl"); //Principalmente, para que el jugador no pueda moverse
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
using UnityEngine;

[System.Serializable]

//Classe personalitzada que dicta que ha de tenir cada linea de dialeg. De moment te el nom del que parla y el text, pero es podria afeguir sorolls o imatges
public class DialogueLine
{
    public string speakerName;
    public string text;

    public DialogueLine(string name, string dialogue)
    {
        speakerName = name;
        text = dialogue;
    }
}

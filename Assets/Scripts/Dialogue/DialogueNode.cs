using UnityEngine;

[System.Serializable]

//Esta classe es el arbol de dialogo de cada personaje
public class DialogueNode

{
    public int index; //Seria la clau del arbre
    public DialogueLine[] dialogueline;
    public bool decision; //Si es true, el jugador tiene que tomar una decisión
    public int where; //Si no hi ha decisió, anirà al numero que posa aqui 


    public DialogueNode(int index, DialogueLine[] dialogueline, bool decision, int where)
    {
        this.index = index;
        this.dialogueline = dialogueline;
        this.decision = decision;
        this.where = where;
    }
}

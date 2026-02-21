using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;

public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    public DialogueVariables(TextAsset globalsfilepath)
    {
        Story globalvariablestory = new Story(globalsfilepath.text);

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach(var variable in globalvariablestory.variablesState)
        {
            Ink.Runtime.Object value = globalvariablestory.variablesState.GetVariableWithName(variable);
            variables.Add(variable, value);
            Debug.Log("Variable global cargada: " + variable + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        VariableToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object newValue)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, newValue);
        }
    }

    private void VariableToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }

}

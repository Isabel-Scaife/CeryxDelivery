using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Single piece of dialogue along with whatever dialogue or choice comes next
/// </summary>
[System.Serializable]
public class DialogueNode
{
    [TextArea(3, 6)] public string text;
    public string id;
    public string nextNodeID;
    public List<DialogueChoice> choices;
}

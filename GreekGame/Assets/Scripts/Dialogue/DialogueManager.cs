using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Shows dialogue in UI, manages dialgoue choices (branching logic), etc.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    // singleton
    public static DialogueManager Instance;

    // fields
    DialogueSO currentDialogue;
    DialogueNode currentNode;
    Dictionary<string, DialogueNode> nodes;

    // functions
    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Shows dialogue
    /// </summary>
    /// <param name="dialogue">all dialogue info for the interaction that should play</param>
    public void BeginDialogue(DialogueSO dialogue)
    {
        // quits if no dialogue was given
        if (dialogue == null) return;
        
        // gets all dialogue for the interaction
        currentDialogue = dialogue;
        nodes = dialogue.nodes.ToDictionary(n => n.id);
        currentNode = nodes[dialogue.startingNodeID];

        // displays dialogue in UI
        DisplayDialogue();
    }

    /// <summary>
    /// Displays dialogue text and/or choices to the player
    /// </summary>
    private void DisplayDialogue()
    {
        // quits if there is nothing to display
        if (currentNode == null) return;

        // shows the current node's text and/or choices
    }
}

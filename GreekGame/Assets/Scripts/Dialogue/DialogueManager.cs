using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

/// <summary>
/// Shows dialogue in UI, manages dialgoue choices (branching logic), etc.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    // singleton
    public static DialogueManager Instance;

    // fields
    private DialogueSO currentDialogue;
    private DialogueNode currentNode;
    private Dictionary<string, DialogueNode> nodes;
    private bool textIsScrolling;
    private float scrollTimer;
    private Queue<char> scrollTextRemaining;
    private bool wantsToAdvance;

    [SerializeField]
    private TextMeshProUGUI dialogueBox;

    public bool DialogueIsHappening { get; private set; }

    // functions
    private void Awake()
    {
        Instance = this;
        textIsScrolling = false;
        wantsToAdvance = false;
        DialogueIsHappening = false;
        scrollTimer = 0.0f;
        scrollTextRemaining = new Queue<char>();
    }

    private void Update()
    {
        // show text one character at a time
        if (textIsScrolling)
        {
            // fills textbox when player chooses to advance
            if (wantsToAdvance)
            {
                wantsToAdvance = false;
                textIsScrolling = false;
                dialogueBox.text = currentNode.text;
            }

            // decrements timer until next character shows
            else if (scrollTimer > 0)
            {
                scrollTimer -= Time.deltaTime;
            }

            // shows next character
            else
            {
                scrollTimer = 0.05f;
                dialogueBox.text += scrollTextRemaining.Dequeue();
                if (scrollTextRemaining.Count < 1)
                {
                    textIsScrolling = false;
                }
            }
        }
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
        currentNode = nodes[currentDialogue.startingNodeID];

        // displays dialogue in UI
        DisplayDialogue();
        DialogueIsHappening = true;
    }

    /// <summary>
    /// Advances dialogue upon player input
    /// </summary>
    public void Advance()
    {
        wantsToAdvance = true;
    }

    /// <summary>
    /// Displays dialogue text and/or choices to the player
    /// </summary>
    private void DisplayDialogue()
    {       
        // quits if there is nothing to display
        if (currentNode == null) return;

        // shows the current node's text
        if (currentNode.choices == null || currentNode.choices.Count < 1)
        {
            // starts showing text character by character
            dialogueBox.text = "";
            scrollTextRemaining.Clear();
            int len = currentNode.text.Length;

            // fills queue with characters that will be procedurally displayed
            for (int i = 0; i < len; i++)
            {
                scrollTextRemaining.Enqueue(currentNode.text[i]);
            }
            textIsScrolling = true;
        }

        // shoes the current node's choices
        else
        {
            // show choices
        }
    }
}

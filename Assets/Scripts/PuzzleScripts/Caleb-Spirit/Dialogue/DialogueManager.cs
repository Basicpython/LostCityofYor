using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextAsset jsonData;
    [SerializeField] Dialogue dialogue;

    public static DialogueManager Instance; 
    void Awake(){ 
        Instance = this; 
    }

    void Start()
    {
        jsonData = Resources.Load<TextAsset>("Caleb-Spirit/Dialogue");
        dialogue = JsonUtility.FromJson<Dialogue>(jsonData.text);
        isSpeaking = false;
        dialogueOpen = GetComponentInChildren<DialogueOpen>();
    }
    
    private List<Phrase> phrases = null;

    public List<Phrase> GetPhrases(string section) {
        switch (section) {
            case "Greeting":
                phrases = dialogue.Greeting;
                break;
            case "Dialogue1":
                phrases = dialogue.Dialogue1;
                break;
            case "CompletedPuzzle1":
                phrases = dialogue.CompletedPuzzle1;
                break;
            case "Dialogue2":
                phrases = dialogue.Dialogue2;
                break;
            case "CompletedPuzzle2":
                phrases = dialogue.CompletedPuzzle2;
                break;
            case "Dialogue3":
                phrases = dialogue.Dialogue3;
                break;
            case "CompletedPuzzle3":
                phrases = dialogue.CompletedPuzzle3;
                break;
            case "Dialogue4":
                phrases = dialogue.Dialogue4;
                break;
            case "CompletedPuzzle4":
                phrases = dialogue.CompletedPuzzle4;
                break;
            case "Dialogue5":
                phrases = dialogue.Dialogue5;
                break;
            case "CompletedPuzzle5":
                phrases = dialogue.CompletedPuzzle5;
                break;
            case "Farewell":
                phrases = dialogue.Farewell;
                break;
            case "Idle":
                phrases = dialogue.Idle;
                break;
            default:
                Debug.LogError("Unknown dialogue section: " + section);
                break;
        }
        return phrases;
    }

    public TMP_Text tmpText;
    private DialogueOpen dialogueOpen;

    public bool isSpeaking;
    public bool isChatQueued { get; private set; }
    private Coroutine chat;

    // Say
    public void Say(Phrase phrase) {
        if (!isSpeaking) {
            if (isChatQueued) {
                StopCoroutine(chat);
                isChatQueued = false;
            }
            StartCoroutine(SayRoutine(phrase));
        } 
    }

    private IEnumerator SayRoutine(Phrase phrase) {
        isSpeaking = true;

        foreach (Line line in phrase.lines) {
            tmpText.text = line.text;
            dialogueOpen.OpenPanel();
            Debug.Log($"SPIRIT: '{line.text}'");

            if (line.time > 0) {
                for (int i = line.time; i > 0 & dialogueOpen.isOpen == true; i--) {
                    yield return new WaitForSeconds(1);
                }

            } else {
                while (dialogueOpen.isOpen == true) {
                    yield return new WaitForSeconds(1);
                }
            }
            //Debug.Log("Closing dialogue");
            dialogueOpen.ClosePanel();
            yield return new WaitForSeconds(0.5f);
        }

        isSpeaking = false;
    }

    // Chat
    public void Chat(List<Phrase> phrases) {
        if (!isSpeaking && !isChatQueued) {
            chat = StartCoroutine(ChatRoutine(phrases));
        }
    }

    // private bool thing;

    private IEnumerator ChatRoutine(List<Phrase> phrases){
        isChatQueued = true;
        while (true) {
            while (isSpeaking) {
                yield return new WaitForSeconds(1f);
            }

            //Debug.Log("Queueing idle chat.");
            yield return new WaitForSeconds(30f + Random.Range(0, 60)); // Time between Chats
            foreach (Phrase phrase in phrases){
                // thing = true;
                if (!phrase.said) {
                    StartCoroutine(SayRoutine(phrase));
                    phrase.said = true;
                    // thing = false;
                    break;
                }
            }
            // if (thing) {
            //     Debug.Log("No more Chats, advancing to next puzzleState");
            //     GameManager.instance.NextState();
            // }
        }
    }
}

[System.Serializable]
public class Dialogue
{
    public List<Phrase> Greeting;
    public List<Phrase> Dialogue1;
    public List<Phrase> CompletedPuzzle1;
    public List<Phrase> Dialogue2;
    public List<Phrase> CompletedPuzzle2;
    public List<Phrase> Dialogue3;
    public List<Phrase> CompletedPuzzle3;
    public List<Phrase> Dialogue4;
    public List<Phrase> CompletedPuzzle4;
    public List<Phrase> Dialogue5;
    public List<Phrase> CompletedPuzzle5;
    public List<Phrase> Farewell;
    public List<Phrase> Idle;
}
 
[System.Serializable]
public class Phrase
{
    public List<Line> lines;
    public bool said;
}

[System.Serializable]
public class Line
{
    public string text;
    public int time;
    public string tone;
}
 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextAsset jsonData;
    [SerializeField] Dialogue dialogue;

    void Start()
    {
        jsonData = Resources.Load<TextAsset>("Caleb-Spirit/Dialogue");
        dialogue = JsonUtility.FromJson<Dialogue>(jsonData.text);
        isSpeaking = false;
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
    public bool isSpeaking { get; private set; }
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

        tmpText.text = phrase.text;
        Debug.Log($"Saying '{phrase.text}'");
        tmpText.enabled = true;

        if (phrase.time > 0) {
            yield return new WaitForSeconds(phrase.time);
        } else {
            yield return new WaitForSeconds(5);
        }

        tmpText.enabled = false;
        isSpeaking = false;
    }

    // Chat
    public void Chat(List<Phrase> phrases) {
        if (!isSpeaking && !isChatQueued) {
            chat = StartCoroutine(ChatRoutine(phrases));
        }
    }

    private IEnumerator ChatRoutine(List<Phrase> phrases){
        isChatQueued = true;
        while (true) {
            Debug.Log("Queueing idle chat");
            yield return new WaitForSeconds(10f);
            foreach (Phrase phrase in phrases){
                if (!phrase.said) {
                    StartCoroutine(SayRoutine(phrase));
                    phrase.said = true;
                    break;
                }
            }
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
    public string text;
    public int time;
    public string tone;
    public bool said;
}
 


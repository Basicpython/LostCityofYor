using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;

public enum PuzzleStateType {
        Inactive,
        Greeting,
        Dialogue1,
        CompletedPuzzle1,
        Dialogue2,
        CompletedPuzzle2,
        Dialogue3,
        CompletedPuzzle3,
        Dialogue4,
        CompletedPuzzle4,
        Dialogue5,
        CompletedPuzzle5,
        Farewell,
        Idle
    }

public class Spirit : MonoBehaviour {
    public static Spirit instance;
    public PuzzleStateType State { get; private set; }
    private bool isSpeaking;
    private Coroutine chat;
    private TextMeshProUGUI textMeshPro;

    private class DialogueEntry {
        public string text;
        public float timeToShow;
        public string tone;
        public bool said;
}

    private Dictionary<string, List<DialogueEntry>> dialogueData;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        State = PuzzleStateType.Inactive;
        isSpeaking = false;

        Transform textTransform = transform.Find("Text");
        if (textTransform == null) {
            Debug.LogWarning("Child GameObject with the name 'Text' not found.");
        }
        
        textMeshPro = textTransform.GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null) {
            Debug.LogWarning("TextMeshPro component not found on 'Text' GameObject.");
        }

        TextAsset dialogueTextAsset = Resources.Load<TextAsset>("Caleb-Spirit/Dialogue");
        dialogueData = JsonUtility.FromJson<Dictionary<string, List<DialogueEntry>>>(dialogueTextAsset.text);
        if (dialogueData == null) {
            Debug.LogWarning("Spirit's dialogue file not loaded.");
        }
        LogDialogueData(dialogueData);

        Say("Greeting");
    }

    void LogDialogueData(Dictionary<string, List<DialogueEntry>> data)
    {
        foreach (KeyValuePair<string, List<DialogueEntry>> pair in data)
        {
            Debug.Log("Section: " + pair.Key);
            List<DialogueEntry> entries = pair.Value;
            foreach (DialogueEntry entry in entries)
            {
                Debug.Log("Text: " + entry.text + ", Time to Show: " + entry.timeToShow + ", Tone: " + entry.tone + ", Said: " + entry.said);
            }
        }
    }

    // Update is called once per frame
    void Update() { // maybe not make this update? find a better way to detect state changes
        switch (State) {
            case PuzzleStateType.Inactive:
                break;
            
            case PuzzleStateType.Greeting:
                // Player just started game, spirit greets player
                Say("Greeting");
                ChangeState(PuzzleStateType.Dialogue1);
                break;

            case PuzzleStateType.Dialogue1:
                // Player is solving Puzzle 1, small talk, hints, lore drops
                chat = StartCoroutine(Chat("Dialogue1")); //coroutine
                if (GameManager.instance.State == GameStateType.SolvedPuzzle1) {
                    ChangeState(PuzzleStateType.CompletedPuzzle1);
                }
                break;
            
            case PuzzleStateType.CompletedPuzzle1:
                // Player solved Puzzle 1, yippee!
                Say("CompletedPuzzle1");
                ChangeState(PuzzleStateType.Dialogue2);
                break;
            /*
            case PuzzleStateType.Dialogue2:
                // Player is solving Puzzle 2, small talk, hints, lore drops
            
            case PuzzleStateType.CompletedPuzzle2:
                // Player solved Puzzle 2, yippee!
                //Say();
                ChangeState(PuzzleStateType.Dialogue3);

            case PuzzleStateType.Dialogue3:
                // Player is solving Puzzle 3, small talk, hints, lore drops
            
            case PuzzleStateType.CompletedPuzzle3:
                // Player solved Puzzle 3, yippee!
                //Say();
                ChangeState(PuzzleStateType.Dialogue4);

            case PuzzleStateType.Dialogue4:
                // Player is solving Puzzle 4, small talk, hints, lore drops
            
            case PuzzleStateType.CompletedPuzzle4:
                // Player solved Puzzle 4, yippee!
                //Say();
                ChangeState(PuzzleStateType.Dialogue5);
            
            case PuzzleStateType.Dialogue5:
                // Player is solving Puzzle 5, small talk, hints, lore drops
            
            case PuzzleStateType.CompletedPuzzle5:
                // Player solved Puzzle 5, yippee!
                //Say();
                ChangeState(PuzzleStateType.Farewell);

            case PuzzleStateType.Farewell:
                // Player finished everything, time to say goodbye :(

            case PuzzleStateType.Idle:
                // Said bye, waiting for player to end
                break;
            */
        }
    }

    public void ChangeState(PuzzleStateType newState) {
        State = newState;
    }


    /**/
    private void Say(string sectionName) {
        while (isSpeaking) { // If spirit is alread saying something
            Thread.Sleep(500); // Wait until dialogue is done
        }

        if (chat != null) {
            StopCoroutine(chat); // Stop chat
        }
        isSpeaking = true; // Now speaking


        if (!dialogueData.ContainsKey(sectionName)) {
            Debug.LogError($"Dialogue section not found: {sectionName}");
        }

        List<DialogueEntry> dialogueEntries = dialogueData[sectionName];
        foreach (DialogueEntry entry in dialogueEntries) {
            if (!entry.said) {
                // make the text appear (entry.text)
                textMeshPro.text = entry.text;
                // sound (entry.tone)

                if (entry.timeToShow == 0f) { // timeToShow = 0
                    // button to make text disapear
                } else { // timeToShow = not 0
                    // timer to make text disapear (entry.timeToShow)
                }

                entry.said = true;
                break;
            } 
        }

        isSpeaking = false; // Not speaking (can chat now)
    }

    IEnumerator Chat(string sectionName) {
        if (!isSpeaking) { // if not speaking
            yield return new WaitForSeconds(30f /*+ rand(0,60)*/); // wait
            Say(sectionName); // speak
        }
    }
}

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
        Idle,
        Done
    }

public class Spirit : MonoBehaviour {
    public static Spirit instance;
    public PuzzleStateType State { get; private set; }

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public DialogueManager dialogueManager;

    public GameObject middleDoor; // because I dont want to change other code and I'm lazy
    public GameObject ritual; // lazy ritual reference
    private PolygonSpawner polygonSpawner;

    // Start is called before the first frame update
    void Start() {
        State = PuzzleStateType.Greeting;

        polygonSpawner = ritual.GetComponent<PolygonSpawner>();
        ritual.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        switch (State) {
            case PuzzleStateType.Inactive:
                break;
            
            case PuzzleStateType.Greeting:
                // Player just started game, spirit greets player
                dialogueManager.Say(dialogueManager.GetPhrases("Greeting")[0]);
                NextState();
                break;

            case PuzzleStateType.Dialogue1:
                // Player is solving Puzzle 1, small talk, hints, lore drops
                if (GameManager.instance.State == GameStateType.SolvedPuzzle1) {
                    NextState();
                } else if (!dialogueManager.isSpeaking) {
                    dialogueManager.Chat(dialogueManager.GetPhrases("Dialogue1"));
                }
                break;
            
            case PuzzleStateType.CompletedPuzzle1:
                // Player solved Puzzle 1, yippee!
                if (!dialogueManager.isSpeaking) {
                    dialogueManager.Say(dialogueManager.GetPhrases("CompletedPuzzle1")[0]);
                    NextState();
                }
                
                break;
            
            case PuzzleStateType.Dialogue2:
                // Player is solving Puzzle 2, small talk, hints, lore drops
                if (GameManager.instance.State == GameStateType.SolvedPuzzle2) {
                    NextState();
                } else if (!dialogueManager.isSpeaking) {
                    dialogueManager.Chat(dialogueManager.GetPhrases("Dialogue2"));
                }
                break;
            
            case PuzzleStateType.CompletedPuzzle2:
                // Player solved Puzzle 2, yippee!
                dialogueManager.Say(dialogueManager.GetPhrases("CompletedPuzzle2")[0]);
                if (!middleDoor.activeSelf) {
                    NextState();
                }
                break;

            case PuzzleStateType.Dialogue3:
                // Player opened middle door
                dialogueManager.Say(dialogueManager.GetPhrases("OpenedMiddleDoor")[0]);

                // Player is solving Puzzle 3, small talk, hints, lore drops
                if (GameManager.instance.State == GameStateType.SolvedPuzzle3) {
                    NextState();
                } else if (!dialogueManager.isSpeaking) {
                    dialogueManager.Chat(dialogueManager.GetPhrases("Dialogue3"));
                }
                break;
            
            case PuzzleStateType.CompletedPuzzle3:
                // Player solved Puzzle 3, yippee!
                dialogueManager.Say(dialogueManager.GetPhrases("CompletedPuzzle3")[0]);
                polygonSpawner.SpawnPolygon(5, 0.5f, -21, 6, 1.5f, 25);
                if (!ritual.activeSelf) {
                    ritual.SetActive(true);
                }
                NextState();
                break;

            case PuzzleStateType.Dialogue4:
                // Player is solving Puzzle 4, small talk, hints, lore drops
                if (GameManager.instance.State == GameStateType.SolvedPuzzle4) {
                    NextState();
                } else if (!dialogueManager.isSpeaking) {
                    dialogueManager.Chat(dialogueManager.GetPhrases("Dialogue4"));
                }
                break;
            
            case PuzzleStateType.CompletedPuzzle4:
                // Player solved Puzzle 4, yippee!
                dialogueManager.Say(dialogueManager.GetPhrases("CompletedPuzzle4")[0]);
                NextState();
                break;
            
            case PuzzleStateType.Dialogue5:
                // Player is solving Puzzle 5, small talk, hints, lore drops
                if (GameManager.instance.State == GameStateType.SolvedPuzzle5) {
                    // NextState();
                } else if (!dialogueManager.isSpeaking) {
                    gameObject.SetActive(false);
                    ritual.SetActive(false);
                    // dialogueManager.Chat(dialogueManager.GetPhrases("Dialogue5"));
                }
                break;
            

            // should not get past this
            case PuzzleStateType.CompletedPuzzle5:
                // Player solved Puzzle 5, yippee!
                dialogueManager.Say(dialogueManager.GetPhrases("CompletedPuzzle5")[0]);
                NextState();
                break;

            case PuzzleStateType.Farewell:
                // Player finished everything, time to say goodbye :(
                dialogueManager.Say(dialogueManager.GetPhrases("Farewell")[0]);
                NextState();
                break;

            case PuzzleStateType.Idle:
                // Said bye, waiting for player to end
                if (GameManager.instance.State == GameStateType.SolvedPuzzle5) {
                    NextState();
                } else if (!dialogueManager.isSpeaking) {
                    dialogueManager.Chat(dialogueManager.GetPhrases("Idle"));
                }
                break;
            
        }
    }

    private void ChangeState(PuzzleStateType newState) {
        Debug.Log($"Changed state from {State} to {newState}");
        State = newState;
    }
    public void NextState() {
        ChangeState((PuzzleStateType)((int)State + 1));
    }
}

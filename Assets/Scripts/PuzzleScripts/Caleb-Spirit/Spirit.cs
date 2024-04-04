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

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start() {
        State = PuzzleStateType.Dialogue1;
    }

    // Update is called once per frame
    void Update() {
        switch (State) {
            case PuzzleStateType.Inactive:
                break;
            
            case PuzzleStateType.Greeting:
                // Player just started game, spirit greets player
                dialogueManager.Say(dialogueManager.GetPhrases("Greeting")[0]);
                //ChangeState(PuzzleStateType.Dialogue1);
                break;

            case PuzzleStateType.Dialogue1:
                // Player is solving Puzzle 1, small talk, hints, lore drops
                if (GameManager.instance.State == GameStateType.SolvedPuzzle1) {
                    ChangeState(PuzzleStateType.CompletedPuzzle1);
                } else if (!dialogueManager.isSpeaking) {
                    dialogueManager.Chat(dialogueManager.GetPhrases("Dialogue1"));
                }
                break;
            
            case PuzzleStateType.CompletedPuzzle1:
                // Player solved Puzzle 1, yippee!
                //Say("CompletedPuzzle1");
                //ChangeState(PuzzleStateType.Dialogue2);
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
        Debug.Log($"Changed state from {State} to {newState}");
        State = newState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType {
        Open,
        Start,
        SolvedPuzzle1,
        SolvedPuzzle2,
        SolvedPuzzle3,
        SolvedPuzzle4,
        SolvedPuzzle5,
        End
    }

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameStateType State { get; private set; }
	public GameObject MiddleButtons;
	public GameObject ExitButtons;
    
    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        State = GameStateType.Open;
		MiddleButtons.SetActive(false);
		ExitButtons.SetActive(false);
    }

    void Update() {
        switch (State) {
            case GameStateType.Open:
                break;
            case GameStateType.Start:
                break;
            case GameStateType.SolvedPuzzle1:
				break;
            case GameStateType.SolvedPuzzle2:
				// after the first two puzzles finish initialize the door buttons
				MiddleButtons.SetActive(true);
                break;
            case GameStateType.SolvedPuzzle3:
                break;
            case GameStateType.SolvedPuzzle4:
				// after the next two puzzles finish initialize the door buttons
				ExitButtons.SetActive(true);
                break;
            case GameStateType.SolvedPuzzle5:
				
                break;
            case GameStateType.End:
                break;
        }
    }

    private void ChangeState(GameStateType newState) {
        State = newState;
    }

    public void NextState() {
        ChangeState((GameStateType)((int)State + 1));
    }
}

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
    
    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        State = GameStateType.Open;
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
                break;
            case GameStateType.SolvedPuzzle3:
                break;
            case GameStateType.SolvedPuzzle4:
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

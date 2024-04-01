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

    public void ChangeState(GameStateType newState) {
        State = newState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public Transform playerOneSpawnLoc, playerTwoSpawnLoc;
    public Trainer playerOne, playerTwo;


    public enum State
    {

        Init,
        Awaiting,
        Attack,
        CheckForWinner,


    }

    public State currentState = State.Init;

    public void ChangeState(State newState)
    {
        currentState = newState;
    }

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Init:
                InitUpdate();

                break;
            case State.Awaiting:
                break;
            case State.Attack:
                break;
            case State.CheckForWinner:
                break;
            default:
                break;
        }
    }
    protected virtual void InitUpdate()
    {
        playerOne.PrepareFighters(playerOneSpawnLoc);
        playerTwo.PrepareFighters(playerTwoSpawnLoc);
        // go to awaiting state
        ChangeState(State.Awaiting);
    }
}

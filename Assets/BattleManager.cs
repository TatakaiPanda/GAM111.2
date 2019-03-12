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
                AwaitingAbilityUpdate();
                break;
            case State.Attack:
                // create a function to take both fighters and deal damaged based on selected ability
                break;
            case State.CheckForWinner:
                //check selected fighter on both sides is alive, if not tell get a new on 
                // check that both sides hae a fighter, if not declare winners
                //tell both trainers that are not ready
                playerOne.isReadyForFight = false;
                playerTwo.isReadyForFight = false; 
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

    protected virtual void AwaitingAbilityUpdate()
    {
        playerOne.onAwaitingSelected();
        playerTwo.onAwaitingSelected();

        if (playerOne.isReadyForFight && playerTwo.isReadyForFight)
        {
            ChangeState(State.Attack);
        }

    }
}

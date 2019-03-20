using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{

    public Transform playerOneSpawnLoc, playerTwoSpawnLoc;
    public Trainer playerOne, playerTwo;
    public Fighter fighterOne, fighterTwo;

    public UnityEvent myEvent;


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
                Debug.Log("Spawning the players");

                break;
            case State.Awaiting:
               Debug.Log("Choosing abillitys");
                AwaitingAbilityUpdate();
                break;
            case State.Attack:
               Debug.Log("Both players are attacking");
                FightSequance();

                // create a function to take both fighters and deal damaged based on selected ability

                break;
            case State.CheckForWinner:
                Debug.Log("CheckingForWinners");
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
    protected virtual void FightSequance()
    {

        playerOne.Attacking();

        playerTwo.Attacking();
        ChangeState(State.CheckForWinner);

        

    }
    
}

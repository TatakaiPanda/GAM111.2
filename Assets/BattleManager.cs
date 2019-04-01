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

    int selectedFighterOne;
    int selectedFighterTwo;
    int dmg;


    public enum State
    {

        Init,
        Awaiting,
        Attack,
        CheckForWinner,
        WhoWon,


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

                selectedFighterOne = playerOne.selectedFighterIndex;
                selectedFighterTwo = playerTwo.selectedFighterIndex;

                fighterOne = playerOne.fighters[selectedFighterOne];
                fighterTwo = playerTwo.fighters[selectedFighterTwo];
                Debug.Log("Spawning the players");

                break;
            case State.Awaiting:
                Debug.Log("Choosing abillitys");
                AwaitingAbilityUpdate();
                break;
            case State.Attack:
                Debug.Log("Both players are attacking");

                // players deal damage
                FightSequance();



                break;
            case State.CheckForWinner:
                Debug.Log("Checking if any fighter is dead");

                //check selected fighter on both sides is alive, if not tell get a new on 
                // check that both sides hae a fighter, if not declare winners
                //tell both trainers that are not ready

                winnerCheck();
                playerOne.isReadyForFight = false;
                playerTwo.isReadyForFight = false;
                break;
            case State.WhoWon:
                Debug.Log("PlayerTwo loses");
                Debug.Log("PlayerOne loses");
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
        fighterOne = playerOne.fighters[selectedFighterOne];
        fighterTwo = playerTwo.fighters[selectedFighterTwo];

        int startVar = Random.Range(0, 1);
        Debug.Log("startVar was: " + startVar);

        // 0 = player two attacks first 1 = player gets to attack first then change states after dealing dmg
        if (startVar == 0)
        {

            fighterOne.hp = fighterOne.hp - fighterTwo.dmg;

            if (fighterOne.hp <= 0)
            {
                ChangeState(State.CheckForWinner);
            }
            else
            {

                fighterTwo.hp = fighterTwo.hp - fighterOne.dmg;

                ChangeState(State.CheckForWinner);
            }


        }
        else
        {
            fighterTwo.hp = fighterTwo.hp - fighterOne.dmg;

            if (fighterTwo.hp <= 0)
            {
                ChangeState(State.CheckForWinner);
            }
            else
            {

                fighterOne.hp = fighterOne.hp - fighterTwo.dmg;

                ChangeState(State.CheckForWinner);

            }
        }
    }
    protected virtual void winnerCheck()
    {

        // both fighters are alive we skip the init phase and jump to choosing abillities
        if (fighterOne.hp > 0 && fighterTwo.hp > 0)
        {

            Debug.Log("Both players are alive, loop again");
            ChangeState(State.Awaiting);
        }

        // If fighterOne is alive and fighterTwo is dead, get a new pokemon for fighterTwo, if fighterTwo dont have anymore fighters playerTwo loses;
        else if (fighterOne.hp > 0 && fighterTwo.hp <= 0)
        {
            Debug.Log("OnePokemond Died");

            if (playerTwo.fighters.Count > 0)
            {

                Debug.Log("Players still have pokemons loop again");
                playerTwo.onCheckingWinners();
                ChangeState(State.Awaiting);

            }
            else
            {

                Debug.Log("trainer dont have anymore pokemons");
                playerTwo.onCheckingWinners();
                Debug.Log("PlayerTwo loses");
                ChangeState(State.WhoWon);


            }
        }

        // if fighterOne is dead and fighterTwo is alive, get a new pokemon for fighterOne, if fighterOne dont have anymore fighters playerOne loses;
        else if (fighterOne.hp <= 0 && fighterTwo.hp > 0)
        {
            Debug.Log("OnePokemond Died");

            if (playerOne.fighters.Count > 0)
            {
                Debug.Log("Players still have pokemons loop again");
                playerOne.onCheckingWinners();
                ChangeState(State.Awaiting);


            }
            else
            {
                Debug.Log("trainer dont have anymore pokemons");
                playerOne.onCheckingWinners();
                ChangeState(State.WhoWon);
            }
        }
    }

}

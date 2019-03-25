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

    int selectedFighter;
    int dmg;


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

        selectedFighter = playerOne.selectedFighterIndex;
        fighterOne = playerOne.fighters[selectedFighter];
        fighterTwo = playerTwo.fighters[selectedFighter];

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

                // players deal damage
                FightSequance();



                break;
            case State.CheckForWinner:
                Debug.Log("CheckingForWinners");
                //check selected fighter on both sides is alive, if not tell get a new on 
                // check that both sides hae a fighter, if not declare winners
                //tell both trainers that are not ready

                winnerCheck();
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
        fighterOne = playerOne.fighters[selectedFighter];
        fighterTwo = playerTwo.fighters[selectedFighter];

        int startVar = Random.Range(0, 1);
        Debug.Log("startVar was: " + startVar);

        // 0 = player two attacks first 1 = player gets to attack first then change states after dealing dmg
        if (startVar == 0)
        {

            fighterOne.hp = fighterOne.hp - fighterTwo.attack(dmg);
            Debug.Log("FighterOnes HP is: " + fighterOne.hp + "FighterTwo dmg is: " + fighterTwo.attack(dmg));

            fighterTwo.hp = fighterTwo.hp - fighterOne.attack(dmg);
            Debug.Log(" FighterTwos HP is: " + fighterTwo.hp + " FighterOnes dmg is: " + fighterOne.attack(dmg));
            ChangeState(State.CheckForWinner);

        }
        else
        {
            fighterTwo.hp = fighterTwo.hp - fighterOne.attack(dmg);
            Debug.Log(" FighterTwos HP is: " + fighterTwo.hp + " FighterOnes dmg is: " + fighterOne.attack(dmg));

            fighterOne.hp = fighterOne.hp - fighterTwo.attack(dmg);
            Debug.Log("FighterOnes HP is: " + fighterOne.hp + "FighterTwo dmg is: " + fighterTwo.attack(dmg));
            ChangeState(State.CheckForWinner);
        }
    }
    protected virtual void winnerCheck()
    {

        if (fighterOne.hp > 0 && fighterTwo.hp > 0)
        {


            // both fighters are alive we skip the init phase and jump to choosing abillities
            ChangeState(State.Awaiting);
        }
        else if (fighterOne.hp > 0 && fighterTwo.hp < 1)
        {

            // if fighterOne is still alive and fighterTwo is dead then fighterOne needs to spawn 1 new pokemon from the list
            playerOne.onCheckingWinners();
            ChangeState(State.Awaiting);
        }
        else if (fighterOne.hp < 1 && fighterTwo.hp > 1)
        {
            // if fighterOne is dead and fighterTwo is still alive
            playerTwo.onCheckingWinners();
            ChangeState(State.Awaiting);
        }
        else
        {
            // if both fighters are dead

            playerOne.onCheckingWinners();
            playerTwo.onCheckingWinners();
            ChangeState(State.Awaiting);
        }
        if (playerOne.fighters.Count == 0)
        {
            // playerOne loses
        }
        else
        {
            // playerTwo losses
        }


    }

}

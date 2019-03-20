using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{

    public List<Fighter> fighterPreFabs = new List<Fighter>();
    public List<Fighter> fighters = new List<Fighter>();
    public int selectedFighterIndex;

    public bool isAi = true;
    public bool isReadyForFight = false;

    

    public void PrepareFighters(Transform spawnLoc)
    {
        if (isAi)
        {
            // for loop som spawnar fighters och lägger dom i en ny lista
            for (int i = 0; i < fighterPreFabs.Count; i++)
            {
                // spawnar fightern i min scene
                var newFighter = Instantiate(fighterPreFabs[Random.Range(0, fighterPreFabs.Count)], spawnLoc.position, spawnLoc.rotation);
                // lägger fighter i en aktiv lista
                fighters.Add(newFighter);

                // stänger av fightern tills den ska användas
                newFighter.gameObject.SetActive(false);

            }
            //due to lack of selected fighter screen, defult to activating one of them
            fighters[selectedFighterIndex].gameObject.SetActive(true);
        }
        else
        {
            // call on player to select fighters from the array
        }
    }
    public void onAwaitingSelected()
    {
        if (isAi)
        {
            fighters[selectedFighterIndex].ChooseRandomAbility();
            isReadyForFight = true;
            
        }
        else
        {
            fighters[selectedFighterIndex].ChooseRandomAbility();
            isReadyForFight = true;


        }
    }
    public void Attacking()
    {



    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

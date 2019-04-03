using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

    public int hp;
    public int dmg;

    public List<Ability> abilities = new List<Ability>();
    public int selectedAbilityIndex;
    public Ability choosenAbility;
    public Trainer isTrainer;

    // Start is called before the first frame update
    void Start()
    {

        isTrainer = FindObjectOfType<Trainer>();

    }


    public void ChooseAbility()
    {
        if (isTrainer.isAi == true)
        {

            selectedAbilityIndex = Random.Range(0, abilities.Count);
            choosenAbility = abilities[selectedAbilityIndex];

            attack();

        }
        else
        {
            selectedAbilityIndex = isTrainer.buttonIndex;
            choosenAbility = abilities[selectedAbilityIndex];

            attack();
        }

    }
    public void attack()
    {


        dmg = abilities[selectedAbilityIndex].dmg;

    }
    
 

    // Update is called once per frame
    void Update()
    {

    }
}

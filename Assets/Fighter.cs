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





    public void ChooseRandomAbility()
    {
        selectedAbilityIndex = Random.Range(0, abilities.Count);
        choosenAbility = abilities[selectedAbilityIndex];

        

        attack();

    }
    public void attack()
    {

        
        dmg = abilities[selectedAbilityIndex].dmg;

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

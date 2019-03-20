using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

    public int hp;

    public List<Ability> abilities = new List<Ability>();
    public int selectedAbilityIndex = -1;
    public Ability choosenAbility;
    



    public void ChooseRandomAbility()
    {
        selectedAbilityIndex = Random.Range(0, abilities.Count);
        choosenAbility = abilities[selectedAbilityIndex];
        Debug.Log(choosenAbility);
        
    }
   public int attack(int dmg)
    {


        return choosenAbility.dmg;
       
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

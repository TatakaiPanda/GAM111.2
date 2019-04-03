using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public List<Button> abillityButtons = new List<Button>();

    public BattleManager managBattles;

    public Text fighterOneHp;
    public Text fighterTwoHp;
    public Text TrainerOneList;
    public Text TrainerTwoList;
    public Text availableAbillityOne;
    public Text availableAbillityTwo;
    public Text availableAbillityThree;
    public Text choosenAbillityDmgOne;
    public Text choosenAbillityDmgTwo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fighterUI();
        TrainerUi();
        AbillitysUI();
    }
    void fighterUI()
    {
        fighterOneHp.text = managBattles.fighterOne.hp.ToString("fighterOnes hp is: " + managBattles.fighterOne.hp);
        fighterTwoHp.text = managBattles.fighterTwo.hp.ToString("fighterOnes hp is: " + managBattles.fighterTwo.hp);
    }
    void AbillitysUI()
    {
        // availableAbillityOne.text = managBattles.fighterOne.abilities[0].ToString();
        // availableAbillityTwo.text = managBattles.fighterOne.abilities[1].ToString();
        //availableAbillityThree.text = managBattles.fighterOne.abilities[2].ToString();



    }
    void TrainerUi()
    {
        TrainerOneList.text = managBattles.playerOne.fighters.Count.ToString("There is this many fighters left in list: " + managBattles.playerOne.fighters.Count);
        TrainerTwoList.text = managBattles.playerTwo.fighters.Count.ToString("There is this many fighters left in list: " + managBattles.playerTwo.fighters.Count);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

   public playerMovement playerController;

    public int chanceOfEncounter;

    int encounterModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (chanceOfEncounter + encounterModifier >= 100)
        {
            Debug.Log("Found enemy in grass!");
        }
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Grass")
        {
            Debug.Log("G");
        }
    }
}



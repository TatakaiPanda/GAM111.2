using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent navAgent;

    public Transform[] travelPos;
    public int chosenTravelPos = -1;

    private int minDelay;
    private int maxDelay;
     

    private bool isLookingToPatroll = false;

    // Start is called before the first frame update
    void Start()
    {

        navAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isLookingToPatroll == true)
        {


            navAgent.destination = travelPos[chosenTravelPos].position;

        }

        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {

            isLookingToPatroll = true;
            chosenTravelPos = Random.Range(0, travelPos.Length);

        }
        else
        {

            isLookingToPatroll = false;

        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("TriggeringBattle");
        }
    }
}

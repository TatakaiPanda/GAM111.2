using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{

    public NavMeshAgent navAgent;

    public bool moving = false;
    // Start is called before the first frame update
    void Start()
    {

        navAgent = GetComponent<NavMeshAgent>();



    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {

            if (Physics.Raycast(ray, out hit, 100))
            {

                navAgent.destination = hit.point;

            }

        }
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

    }
}

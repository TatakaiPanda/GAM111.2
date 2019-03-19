using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEvent : MonoBehaviour
{

    public UnityEvent myFirstEvent, mySecondEvent;
    // Start is called before the first frame update
    void Start()
    {

        myFirstEvent.Invoke(); // this is like hitting post on twitter

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

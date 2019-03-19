using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleScript : MonoBehaviour
{

    public List<int> ints = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ints.Count; i++)
        {
            var tmp = ints[i];

            var rIndex = Random.Range(0, ints.Count);

            ints[i] = ints[rIndex];
            ints[rIndex] = tmp;
        }

    }
}

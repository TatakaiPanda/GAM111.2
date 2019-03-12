﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{

    public List<Fighter> fighterPreFabs = new List<Fighter>();
    public List<Fighter> fighters = new List<Fighter>();
    public int selectedFighterIndex;

    public void PrepareFighters(Transform spawnLoc)
    {
        for (int i = 0; i < fighterPreFabs.Count; i++)
        {
            var newFighter = Instantiate(fighterPreFabs[0], spawnLoc.position, spawnLoc.rotation);
            fighters.Add(newFighter);
            newFighter.gameObject.SetActive(false);
        }
        //due to lack of selected fighter screen, defult to activating one of them
        fighters[selectedFighterIndex].gameObject.SetActive(true);

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

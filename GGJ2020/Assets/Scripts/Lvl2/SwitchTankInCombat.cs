using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTankInCombat : MonoBehaviour
{
    private Transform[] blueTanks;
    private Transform[] redTanks;

    private int activeRed = 0;
    private int activevBlue = 0;

    private void Start()
    {
        GetTanks();
    }

    private void GetTanks()
    {
        GameObject blueHolder = GameObject.Find("BlueTanks");
        GameObject redHolder = GameObject.Find("RedTanks");
        blueTanks = new Transform[blueHolder.transform.childCount];
        redTanks = new Transform[redHolder.transform.childCount];

        // Reference children
        for (int i = 0; i < blueHolder.transform.childCount; i++)
        {
            blueTanks[i] = blueHolder.transform.GetChild(i);
            redTanks[i] = redHolder.transform.GetChild(i);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SwitchToNextRed();
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchToNextBlue();
        }
    }

    private void SwitchToNextRed()
    {
        redTanks[activeRed].GetComponent<Movement>().isControlled = false;
        
        if(activeRed < redTanks.Length - 1)
        {
            activeRed++;
        }
        else
        {
            activeRed = 0;
        }

        redTanks[activeRed].GetComponent<Movement>().isControlled = true;
    }

    private void SwitchToNextBlue()
    {
        blueTanks[activevBlue].GetComponent<Movement>().isControlled = false;

        if (activevBlue < blueTanks.Length - 1)
        {
            activevBlue++;
        }
        else
        {
            activevBlue = 0;
        }

        blueTanks[activevBlue].GetComponent<Movement>().isControlled = true;
    }
}

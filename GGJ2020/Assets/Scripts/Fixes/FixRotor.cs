﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotor : MonoBehaviour
{
    public bool isBroken { get; set; }

    private GameObject rotorPart = null;
    private bool isFixing;

    private readonly float repairDuration = 5f;

    private void Awake()
    {
        rotorPart = transform.Find("SnakePart").gameObject;

        Break();
    }

    public void Break()
    {
        isBroken = true;
        rotorPart.SetActive(false);
    }

    public void Fix()
    {
        if(!isFixing && isBroken)
        {
            StartCoroutine(Fixing());
        }
    }

    private IEnumerator Fixing()
    {
        isFixing = true;
        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(true);

        float counter = 0f;
        while(counter < repairDuration)
        {
            Main.Instance.repairProgress.fillAmount = counter / repairDuration;
            counter += Time.deltaTime;
            yield return null;
        }

        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(false);
        rotorPart.SetActive(true);
        isBroken = false;
        isFixing = false;
    }
}
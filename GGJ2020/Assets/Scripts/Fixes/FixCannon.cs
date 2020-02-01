﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCannon : MonoBehaviour
{
    public bool isBroken { get; set; }

    private GameObject cannonPart = null;
    private GameObject cannonBrokenPart = null;
    private bool isFixing;

    private readonly float repairDuration = 5f;

    private void Awake()
    {
        cannonPart = transform.Find("UpperBody").Find("Cannon").gameObject;
        cannonBrokenPart = transform.Find("UpperBody").Find("Cannon_Broken").gameObject;

        Break();
    }

    public void Break()
    {
        isBroken = true;
        cannonPart.SetActive(false);
        cannonBrokenPart.SetActive(true);

    }

    public void Fix()
    {
        if (!isFixing && isBroken)
        {
            StartCoroutine(Fixing());
        }
    }

    private IEnumerator Fixing()
    {
        isFixing = true;
        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(true);

        float counter = 0f;
        while (counter < repairDuration)
        {
            Main.Instance.repairProgress.fillAmount = counter / repairDuration;
            counter += Time.deltaTime;
            yield return null;
        }

        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(false);
        cannonBrokenPart.SetActive(false);
        cannonPart.SetActive(true);
        isBroken = false;
        isFixing = false;
    }
}

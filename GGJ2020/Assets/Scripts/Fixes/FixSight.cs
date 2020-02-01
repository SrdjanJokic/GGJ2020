using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixSight : MonoBehaviour
{
    public bool isBroken { get; set; }

    private GameObject sightPart = null;
    private GameObject sightBrokenPart = null;
    private bool isFixing;

    private readonly float repairDuration = 5f;

    private void Awake()
    {
        sightPart = transform.Find("UpperBody").Find("LookingGlass").gameObject;
        sightBrokenPart = transform.Find("UpperBody").Find("LookingGlassBroken").gameObject;

        Break();
    }

    public void Break()
    {
        isBroken = true;
        sightPart.SetActive(false);
        sightBrokenPart.SetActive(true);

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
        sightBrokenPart.SetActive(false);
        sightPart.SetActive(true);
        isBroken = false;
        isFixing = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixSight : MonoBehaviour
{
    public bool isBroken { get; set; }

    private GameObject sightPart = null;
    private GameObject sightBrokenPart = null;

    private readonly float repairDuration = 2f;

    private void Awake()
    {
        sightPart = transform.Find("Aimer").Find("UpperBody").Find("LookingGlass").gameObject;
        sightBrokenPart = transform.Find("Aimer").Find("UpperBody").Find("LookingGlassBroken").gameObject;
    }

    public void Break()
    {
        isBroken = true;
        sightPart.SetActive(false);
        sightBrokenPart.SetActive(true);

    }

    public void Fix()
    {
        if (((!Main.Instance.blueIsRepOrUp && transform.CompareTag("Blue") && Main.Instance.controllerOfEdits.GetBlueEdits() > 0) ||
            (!Main.Instance.redIsRepOrUp && transform.CompareTag("Red") && Main.Instance.controllerOfEdits.GetRedEdits() > 0)) && isBroken)
        {
            StartCoroutine(Fixing());
        }
    }

    private IEnumerator Fixing()
    {
        SetRepTag(true);
        UnityEngine.UI.Image progress = transform.CompareTag("Blue") ? Main.Instance.blueRepairProgress : Main.Instance.redRepairProgress;
        progress.transform.parent.gameObject.SetActive(true);

        float counter = 0f;
        while (counter < repairDuration)
        {
            progress.fillAmount = counter / repairDuration;
            counter += Time.deltaTime;
            yield return null;
        }

        progress.transform.parent.gameObject.SetActive(false);
        sightBrokenPart.SetActive(false);
        sightPart.SetActive(true);
        isBroken = false;
        SetRepTag(false);
        LowerEdits();
    }

    private void LowerEdits()
    {
        if (transform.CompareTag("Blue"))
        {
            Main.Instance.controllerOfEdits.LowerBlueEdits();
        }
        else
        {
            Main.Instance.controllerOfEdits.LowerRedEdits();
        }
    }

    private void SetRepTag(bool val)
    {
        if (transform.CompareTag("Blue"))
        {
            Main.Instance.blueIsRepOrUp = val;
        }
        else
        {
            Main.Instance.redIsRepOrUp = val;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArmor : MonoBehaviour
{
    public bool notUpgraded { get; set; }

    private GameObject armorPart = null;

    private readonly float repairDuration = 2f;

    private void Awake()
    {
        armorPart = transform.Find("Armor").gameObject;
    }

    public void RemoveUpgrade()
    {
        notUpgraded = true;
        armorPart.SetActive(false);
    }

    public void Upgrade()
    {
        if (((!Main.Instance.blueIsRepOrUp && transform.CompareTag("Blue") && Main.Instance.controllerOfEdits.GetBlueEdits() > 0) ||
            (!Main.Instance.redIsRepOrUp && transform.CompareTag("Red") && Main.Instance.controllerOfEdits.GetRedEdits() > 0)) && notUpgraded)
        {
            StartCoroutine(Upgrading());
        }
    }

    private IEnumerator Upgrading()
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
        armorPart.SetActive(true);
        notUpgraded = false;
        SetRepTag(false);

        LowerEdits();
    }

    private void LowerEdits()
    {
        if(transform.CompareTag("Blue"))
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPower : MonoBehaviour
{
    public bool notUpgraded { get; set; }

    private GameObject armorPart = null;
    private bool isUpgrading;

    private readonly float repairDuration = 5f;

    private void Awake()
    {
        //powerPart = transform.Find("Armor").gameObject;

        RemoveUpgrade();
    }

    public void RemoveUpgrade()
    {
        notUpgraded = true;
        Debug.Log("Upgrade Removed");
        //powerPart.SetActive(false);
    }

    public void Upgrade()
    {
        if (!isUpgrading && notUpgraded)
        {
            StartCoroutine(Upgrading());
        }
    }

    private IEnumerator Upgrading()
    {
        isUpgrading = true;
        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(true);

        float counter = 0f;
        while (counter < repairDuration)
        {
            Main.Instance.repairProgress.fillAmount = counter / repairDuration;
            counter += Time.deltaTime;
            yield return null;
        }

        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(false);
        //powerPart.SetActive(true);
        Debug.Log("Upgrade Placed");
        notUpgraded = false;
        isUpgrading = false;
    }
}

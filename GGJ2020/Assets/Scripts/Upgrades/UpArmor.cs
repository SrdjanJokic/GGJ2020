using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArmor : MonoBehaviour
{
    public bool notUpgraded { get; set; }

    private GameObject armorPart = null;

    private readonly float repairDuration = 5f;

    private void Awake()
    {
        armorPart = transform.Find("Armor").gameObject;

        RemoveUpgrade();
    }

    public void RemoveUpgrade()
    {
        notUpgraded = true;
        armorPart.SetActive(false);
    }

    public void Upgrade()
    {
        if (!Main.Instance.isRepOrUp && notUpgraded)
        {
            StartCoroutine(Upgrading());
        }
    }

    private IEnumerator Upgrading()
    {
        Main.Instance.isRepOrUp = true;
        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(true);

        float counter = 0f;
        while (counter < repairDuration)
        {
            Main.Instance.repairProgress.fillAmount = counter / repairDuration;
            counter += Time.deltaTime;
            yield return null;
        }

        Main.Instance.repairProgress.transform.parent.gameObject.SetActive(false);
        armorPart.SetActive(true);
        notUpgraded = false;
        Main.Instance.isRepOrUp = false;
    }
}

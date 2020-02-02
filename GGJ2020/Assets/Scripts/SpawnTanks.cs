using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTanks : MonoBehaviour
{
    public static int currentRound = 1;

    [SerializeField] private GameObject blueTank = null;
    [SerializeField] private GameObject redTank = null;
    [SerializeField] private Transform blueSpawn = null;
    [SerializeField] private Transform redSpawn = null;

    private void Start()
    {
        SpawnFirstRound();
    }

    private void SpawnFirstRound()
    {
        // Spawn blue
        FirstRoundFirstTank(Instantiate(blueTank, blueSpawn.position, Quaternion.Euler(0f, 90f, 0f), blueSpawn));
        FirstRoundSecondTank(Instantiate(blueTank, blueSpawn.position, Quaternion.Euler(0f, 90f, 0f), blueSpawn));
        FirstRoundThirdTank(Instantiate(blueTank, blueSpawn.position, Quaternion.Euler(0f, 90f, 0f), blueSpawn));

        // Spawn red
        FirstRoundFirstTank(Instantiate(redTank, redSpawn.position, Quaternion.Euler(0f, 90f, 0f), redSpawn));
        FirstRoundSecondTank(Instantiate(redTank, redSpawn.position, Quaternion.Euler(0f, 90f, 0f), redSpawn));
        FirstRoundThirdTank(Instantiate(redTank, redSpawn.position, Quaternion.Euler(0f, 90f, 0f), redSpawn));

        for (int i = 1; i < blueSpawn.childCount; i++)
        {
            blueSpawn.GetChild(i).gameObject.SetActive(false);
            redSpawn.GetChild(i).gameObject.SetActive(false);
        }

        // TEMP
        Main.Instance.activeBlueTank = blueSpawn.GetChild(0).gameObject;
        Main.Instance.activeRedTank = redSpawn.GetChild(0).gameObject;
    }

    private void FirstRoundFirstTank(GameObject firstTank)
    {
        firstTank.GetComponent<FixRotor>().Break();
        firstTank.GetComponent<UpPower>().RemoveUpgrade();
    }

    private void FirstRoundSecondTank(GameObject secondTank)
    {
        secondTank.GetComponent<FixSight>().Break();
        secondTank.GetComponent<UpArmor>().RemoveUpgrade();
        secondTank.GetComponent<UpPower>().RemoveUpgrade();
    }

    private void FirstRoundThirdTank(GameObject thirdTank)
    {
        thirdTank.GetComponent<FixRotor>().Break();
        thirdTank.GetComponent<UpArmor>().RemoveUpgrade();
    }
}

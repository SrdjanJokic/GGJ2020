using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixesAndUpgaresUI : MonoBehaviour
{
    #region Blue
    public void FixBlueCannon()
    {
        Main.Instance.activeBlueTank.GetComponent<FixCannon>().Fix();
    }
    public void FixBlueRotor()
    {
        Main.Instance.activeBlueTank.GetComponent<FixRotor>().Fix();
    }
    public void FixBlueSight()
    {
        Main.Instance.activeBlueTank.GetComponent<FixSight>().Fix();
    }
    public void UpBlueArmor()
    {
        Main.Instance.activeBlueTank.GetComponent<UpArmor>().Upgrade();
    }
    public void UpBluePower()
    {
        Main.Instance.activeBlueTank.GetComponent<UpPower>().Upgrade();
    }
    #endregion

    #region Red
    public void FixRedCannon()
    {
        Main.Instance.activeRedTank.GetComponent<FixCannon>().Fix();
    }
    public void FixRedRotor()
    {
        Main.Instance.activeRedTank.GetComponent<FixRotor>().Fix();
    }
    public void FixRedSight()
    {
        Main.Instance.activeRedTank.GetComponent<FixSight>().Fix();
    }
    public void UpRedArmor()
    {
        Main.Instance.activeRedTank.GetComponent<UpArmor>().Upgrade();
    }
    public void UpRedPower()
    {
        Main.Instance.activeRedTank.GetComponent<UpPower>().Upgrade();
    }
    #endregion
}

using UnityEngine;
using TMPro;

public class SwapTank : MonoBehaviour
{
    [SerializeField] private bool isBlue = false;
    [SerializeField] private Transform spawn = null;
    private int currentTank = 0;

    public void SendToRight()
    {
        if(currentTank < spawn.childCount - 1)
        {
            spawn.GetChild(currentTank).gameObject.SetActive(false);
            currentTank++;
            spawn.GetChild(currentTank).gameObject.SetActive(true);

            if (isBlue)
            {
                Main.Instance.activeBlueTank = spawn.GetChild(currentTank).gameObject;
            }
            else
            {
                Main.Instance.activeRedTank = spawn.GetChild(currentTank).gameObject;
            }
        }
    }

    public void SendToLeft()
    {
        if (currentTank > 0)
        {
            spawn.GetChild(currentTank).gameObject.SetActive(false);
            currentTank--;
            spawn.GetChild(currentTank).gameObject.SetActive(true);

            if (isBlue)
            {
                Main.Instance.activeBlueTank = spawn.GetChild(currentTank).gameObject;
            }
            else
            {
                Main.Instance.activeRedTank = spawn.GetChild(currentTank).gameObject;
            }
        }
    }
}

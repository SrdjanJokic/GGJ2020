using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main Instance;

    // UI
    public Image blueRepairProgress;
    public Image redRepairProgress;

    // Active tanks
    [HideInInspector] public GameObject activeBlueTank;
    [HideInInspector] public GameObject activeRedTank;

    [HideInInspector] public bool redIsRepOrUp;
    [HideInInspector] public bool blueIsRepOrUp;

    private void Awake()
    {
        Instance = this;
    }
}

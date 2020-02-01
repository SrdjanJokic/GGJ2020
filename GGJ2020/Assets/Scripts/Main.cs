using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main Instance;

    // UI
    public Image repairProgress;

    private void Awake()
    {
        Instance = this;
    }
}

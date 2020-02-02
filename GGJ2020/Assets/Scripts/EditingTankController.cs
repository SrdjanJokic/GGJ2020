using UnityEngine;
using TMPro;

public class EditingTankController : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private TextMeshProUGUI blueCounter;
    [SerializeField] private TextMeshProUGUI redCounter;

    private int remainingBlueEdits = 4;
    private int remainingRedEdits = 4;

    private void Start()
    {
        blueCounter.text = remainingBlueEdits.ToString();
        redCounter.text = remainingRedEdits.ToString();
    }

    private void CheckIfToLoadNextScene()
    {
        if(remainingBlueEdits == 0 && remainingRedEdits == 0)
        {
            levelLoader.LevelLoad(1);
        }
    }

    public int GetBlueEdits()
    {
        return remainingBlueEdits;
    }

    public int GetRedEdits()
    {
        return remainingRedEdits;
    }

    public void LowerBlueEdits()
    {
        remainingBlueEdits--;
        blueCounter.text = remainingBlueEdits.ToString();
        CheckIfToLoadNextScene();
    }

    public void LowerRedEdits()
    {
        remainingRedEdits--;
        redCounter.text = remainingRedEdits.ToString();
        CheckIfToLoadNextScene();
    }
}

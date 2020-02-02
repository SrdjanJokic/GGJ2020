using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RedUISelector : MonoBehaviour
{
    [SerializeField] private GameObject[] topButtons = null;
    [SerializeField] private GameObject[] botButtons = null;
    [SerializeField] private EventSystem redEventSystem = null;

    private GameObject currentlySelected;
    private bool isInTopRow = true;
    private int selectedInRowCounter = 0;

    private void Start()
    {
        currentlySelected = topButtons[0];
        redEventSystem.SetSelectedGameObject(currentlySelected);
    }

    private void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentlySelected.GetComponent<Button>().onClick.Invoke();
        }
    }

    private void HandleMovement()
    {
        // Switch to top row
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentlySelected = topButtons[0];
            redEventSystem.SetSelectedGameObject(currentlySelected);

            selectedInRowCounter = 0;
            isInTopRow = true;
        }

        // Switch to bottom row
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentlySelected = botButtons[0];
            redEventSystem.SetSelectedGameObject(currentlySelected);

            selectedInRowCounter = 0;
            isInTopRow = false;
        }

        // Go left in current row
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedInRowCounter == 0) return;

            selectedInRowCounter--;
            currentlySelected = isInTopRow ? topButtons[selectedInRowCounter] : botButtons[selectedInRowCounter];
            redEventSystem.SetSelectedGameObject(currentlySelected);
        }

        // Go right in the row
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isInTopRow && selectedInRowCounter == topButtons.Length - 1) return;
            if (!isInTopRow && selectedInRowCounter == botButtons.Length - 1) return;

            selectedInRowCounter++;
            currentlySelected = isInTopRow ? topButtons[selectedInRowCounter] : botButtons[selectedInRowCounter];
            redEventSystem.SetSelectedGameObject(currentlySelected);
        }
    }
}

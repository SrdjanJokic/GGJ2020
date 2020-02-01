using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlueUISelector : MonoBehaviour
{
    [SerializeField] private GameObject[] topButtons = null;
    [SerializeField] private GameObject[] botButtons = null;

    private GameObject currentlySelected;
    private bool isInTopRow = true;
    private int selectedInRowCounter = 0;

    private void Start()
    {
        currentlySelected = topButtons[0];
        EventSystem.current.SetSelectedGameObject(currentlySelected);
    }
    
    private void Update()
    {
        HandleMovement();

        if(Input.GetKeyDown(KeyCode.F))
        {
            currentlySelected.GetComponent<Button>().onClick.Invoke();
        }
    }

    private void HandleMovement()
    {
        // Switch to top row
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentlySelected = topButtons[0];
            EventSystem.current.SetSelectedGameObject(currentlySelected);

            selectedInRowCounter = 0;
            isInTopRow = true;
        }

        // Switch to bottom row
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentlySelected = botButtons[0];
            EventSystem.current.SetSelectedGameObject(currentlySelected);

            selectedInRowCounter = 0;
            isInTopRow = false;
        }

        // Go left in current row
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (selectedInRowCounter == 0) return;

            selectedInRowCounter--;
            currentlySelected = isInTopRow ? topButtons[selectedInRowCounter] : botButtons[selectedInRowCounter];
            EventSystem.current.SetSelectedGameObject(currentlySelected);
        }

        // Go right in the row
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isInTopRow && selectedInRowCounter == topButtons.Length - 1) return;
            if (!isInTopRow && selectedInRowCounter == botButtons.Length - 1) return;

            selectedInRowCounter++;
            currentlySelected = isInTopRow ? topButtons[selectedInRowCounter] : botButtons[selectedInRowCounter];
            EventSystem.current.SetSelectedGameObject(currentlySelected);
        }
    }

}

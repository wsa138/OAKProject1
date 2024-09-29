using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public MultiplayerDataSO multiplayerData; // Access the MultiplayerData Scriptable Object for this project.

    [SerializeField] Button  addPlayerButton;

    // Start is called before the first frame update
    void Start()
    {
        addPlayerButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Debug.Log(addPlayerButton.name);
    }

}

// Add text showing the multiplayerData.numberOfPlayers
// Increment number of players when add player button is clicked.
// When start game button is clicked, move to next screen which should log the total number of players.

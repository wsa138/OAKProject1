using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public MultiplayerDataSO multiplayerData; // Access the MultiplayerData Scriptable Object for this project.

    [SerializeField] Button addPlayerButton;
    [SerializeField] Button removePlayerButton;
    [SerializeField] Button startGameButton;
    [SerializeField] TextMeshProUGUI numberOfPlayersText;

    // Start is called before the first frame update
    void Start()
    {
        // Set button listeners.
        addPlayerButton.onClick.AddListener(OnAddPlayerButtonClick);
        removePlayerButton.onClick.AddListener(OnRemovePlayerButtonClick);
        startGameButton.onClick.AddListener(OnStartGameButtonClick);

        // Reset the number of players
        multiplayerData.numberOfPlayers = 1;
    }

    private void OnAddPlayerButtonClick()
    {
        // Check if the max number of players is reached. If no, increment.
        if (multiplayerData.numberOfPlayers == 4)
        {
            return;
        } else
        {
            multiplayerData.numberOfPlayers++;
        }        

        UpdateNumberOfPlayersText();
        Debug.Log(multiplayerData.numberOfPlayers);
    }

    private void OnStartGameButtonClick()
    {
        SceneManager.LoadScene("BattleScene1");
    }

    private void UpdateNumberOfPlayersText()
    {
        numberOfPlayersText.text = multiplayerData.numberOfPlayers.ToString();
    }

    private void OnRemovePlayerButtonClick()
    {
        // Check if the min number of players is reached. If no, decrement.
        if (multiplayerData.numberOfPlayers == 1)
        {
            return;
        }
        else
        {
            multiplayerData.numberOfPlayers--;
        }

        UpdateNumberOfPlayersText();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text BestScoreText;
    [SerializeField] TMP_InputField NameInputTextArea;

    private void Start()
    {
        int highScore = DataManager.Instance.HighScore;
        string highScoreName = DataManager.Instance.HighScorePlayerName;

        BestScoreText.text = $"Best Score of {highScore} goes to {highScoreName}";
        NameInputTextArea.text = DataManager.Instance.PlayerName;
    }

    public void StartNew()
    {
        DataManager.Instance.PlayerName = NameInputTextArea.text;
        DataManager.Instance.SaveLastPlayer();
        SceneManager.LoadScene(1);
    }
}

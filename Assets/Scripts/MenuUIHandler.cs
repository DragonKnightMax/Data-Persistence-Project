using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TMP_Text BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayBestScore()
    {
        string playerName = DataManager.Instance.BestPlayerName;
        int bestScore = DataManager.Instance.BestScore;
        BestScoreText.text = $"Best Score: {playerName} : {bestScore}";
    }

    // start game
    public void StartNew()
    {
        if (NameInputField.text.Length == 0)
        {
            Debug.Log("Name must not be empty!");
            return;
        }
        // set player name
        //Debug.Log("Player Name: " + NameInputField.text);
        DataManager.Instance.CurrentPlayerName = NameInputField.text;

        SceneManager.LoadScene("main");
    }

    // exit game
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject entryFieldContainer;
    public GameObject titleUIContainer;
    public TextMeshProUGUI mInputField;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        highScoreText.text = "The Current Highscore holder is : " + DataManager.Instance.player.playerName + " , " + DataManager.Instance.player.points + " !";
    }

    public void StartEnterName()
    {
        titleUIContainer.SetActive(false);
        entryFieldContainer.SetActive(true);
    }

    public void StartGame()
    {
        DataManager.Instance.currentPlayerName = mInputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

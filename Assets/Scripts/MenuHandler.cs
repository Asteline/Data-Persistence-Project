using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public Text bestScoreText, nameText;

    private void Start()
    {
        MenuManager.Instance.LoadScore();
        bestScoreText.text = "Best Score: " + MenuManager.Instance.bestScoreName + " : " + MenuManager.Instance.bestScore;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MenuManager.Instance.SaveScore(MenuManager.Instance.bestScore);

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void CurrentName()
    {
        MenuManager.Instance.currentName = nameText.text;
    }
}

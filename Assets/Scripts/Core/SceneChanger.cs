using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    [SerializeField] string menuSceneName;
    [SerializeField] string howToPlaySceneName;
    [SerializeField] string creditsSceneName;
    [SerializeField] string gameSceneName;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }
    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene(howToPlaySceneName);
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(creditsSceneName);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject levels;
    public GameObject howToPlay;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelsGame()
    {
        levels.SetActive(!levels.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(!howToPlay.activeSelf);
    }

    public void SetLevel(string nameLevel)
    {
        Data.importantScore = SceneUtility.GetBuildIndexByScenePath(nameLevel)-1;
        SceneManager.LoadScene(nameLevel);
    }
}

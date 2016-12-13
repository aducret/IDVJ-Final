using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject optionsPanel;
    public GameObject instructionsPanel;
    public GameObject levelSelectPanel;
    public GameObject levelSelectTitle;

    void Start()
    {
        levelSelectTitle.SetActive(false);
        instructionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void goToLevelSelectPanel()
    {
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void goToInstructionsPanel()
    {
        optionsPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void goToOptionsPanel()
    {
        instructionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void goToLevel(int level)
    {
        SceneManager.LoadScene("Level " + level);
    }
}

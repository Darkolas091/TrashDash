using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject aboutPanel;

    [SerializeField] private GameManager gameManager;


    private void Start()
    {
        ShowMainMenuPanel();
    }

    public void ShowMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }
    public void ShowOptionsPanel()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void OnPlayButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        gameManager.StartGame();
    }

}

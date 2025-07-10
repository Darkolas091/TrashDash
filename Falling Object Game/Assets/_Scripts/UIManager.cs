using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Interactions")]
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private Slider volumeSlider;



    [SerializeField] private GameManager gameManager;





    private void Start()
    {
        ShowMainMenuPanel();
    }

    public void ShowMainMenuPanel()
    {
        AudioManager.Instance.PlayButtonClick();
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        aboutPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    public void ShowOptionsPanel()
    {
        AudioManager.Instance.PlayButtonClick();
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void ShowAboutPanel()
    {
        AudioManager.Instance.PlayButtonClick();
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void OnPlayButtonClicked()
    {
        AudioManager.Instance.PlayButtonClick();
        mainMenuPanel.SetActive(false);
        gameManager.StartGame();
    }

    public void OnVolumeSliderChanged()
    {
        AudioManager.Instance.PlayButtonClick();
        float value = volumeSlider.value;
        AudioListener.volume = value;
        volumeText.text = $"{value}%";
    }

    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }


}

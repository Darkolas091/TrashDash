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

    [Header("Image and Text")]
    [SerializeField] private GameObject imageToShow;
    [SerializeField] private TMP_Text textToChangeColor;


    [SerializeField] private GameManager gameManager;





    private void Start()
    {
        AudioManager.Instance.PlayLoseMusic();
        ShowMainMenuPanel();
    }

    public void ShowMainMenuPanel()
    {
        //AudioManager.Instance.StopBackgroundMusic();
        //AudioManager.Instance.PlayLoseMusic();

        if (imageToShow != null)
        {
            imageToShow.SetActive(false);
            textToChangeColor.color = Color.white; // Reset to default color
        }
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
        float value = volumeSlider.value;
        // Map slider value (0-100) to AudioListener.volume (0-0.5)
        float mappedVolume = Mathf.Clamp01(value / 100f) * 0.5f;
        AudioListener.volume = mappedVolume;
        volumeText.text = $"{value}%";
    }


    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void OnExitButtonClicked()
    {
        AudioManager.Instance.PlayButtonClick();
        Application.Quit();
    }


}

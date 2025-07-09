using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip pickupClip;
    [SerializeField] private AudioClip buttonClickClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayPickup()
    {
        sfxSource.PlayOneShot(pickupClip);
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClickClip);
    }
}

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip backgroundMusicClip;
    [SerializeField] private AudioClip loseMusicClip;

    [Header("SFX")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip pickupGoodClip;
    [SerializeField] private AudioClip pickupBadClip;
    [SerializeField] private AudioClip buttonClickClip;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        SetNewGameMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource.clip != backgroundMusicClip)
        {
            musicSource.clip = backgroundMusicClip;
        }
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void PlayLoseMusic()
    {
        if (musicSource.clip != loseMusicClip)
        {
            musicSource.clip = loseMusicClip;
        }
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void SetNewGameMusic()
    {
        musicSource.clip = backgroundMusicClip;
    }

    public void PlayMainMenuMusic()
    {
        PlayLoseMusic();
    }

    public void PlayPickupGood()
    {
        sfxSource.PlayOneShot(pickupGoodClip);
    }
    public void PlayPickupBad()
    {
        sfxSource.PlayOneShot(pickupBadClip);
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClickClip);
    }
}

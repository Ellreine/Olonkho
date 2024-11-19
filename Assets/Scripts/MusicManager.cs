using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] private float FadingTimer;
    [SerializeField] private AudioClip[] LevelMusic;
    [SerializeField] private AudioSource tempSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        SetCurrentLevelTrack();
    }

    public void SetCurrentLevelTrack()
    {
        SoundManager.instance.musicSource.clip = LevelMusic[PlayerPrefs.GetInt("currentLevel", 1)];
    }

        private void ChangeMusic(AudioClip nextMusic)
        {
        tempSource.clip = nextMusic;
        StartCoroutine(SwappingTracks(nextMusic));

        }

    public void ActivateMiddleMusic(int levelIndex)
    {
        ChangeMusic(LevelMusic[levelIndex]);
    }

    IEnumerator SwappingTracks(AudioClip nextMusic)
    {
        float timepassed = 0;
        while (timepassed < FadingTimer)
        {
            SoundManager.instance.musicSource.volume = Mathf.Lerp(1, 0, timepassed / FadingTimer);
            tempSource.volume = Mathf.Lerp(0, 1, timepassed / FadingTimer);
            timepassed += Time.deltaTime;
            yield return null;
        }

        //music source get new music
        SoundManager.instance.musicSource.clip = nextMusic;
        //music source get normal volume
        SoundManager.instance.ChangeMusicVolume(1f);
        //music source start playing
        SoundManager.instance.musicSource.Play();
        // temp source stop playing and volume get 0
        tempSource.Stop();
        tempSource.volume = 0f;
    }
}

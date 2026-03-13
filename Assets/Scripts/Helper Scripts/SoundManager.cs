using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource soundFX;
    [SerializeField] private AudioSource bgMusic; // drag the same GameObject's AudioSource here

    [SerializeField] private AudioClip landClip, deathClip, iceBreakClip, gameOverClip;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject); // persist across scenes!
        } else {
            Destroy(gameObject);
            return;
        }

        // Restore saved settings on startup
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        bool savedMute = PlayerPrefs.GetInt("Muted", 0) == 1;

        ApplyVolume(savedVolume);
        ApplyMute(savedMute);
    }

    private void ApplyVolume(float volume) {
        soundFX.volume = volume;
        if (bgMusic != null) bgMusic.volume = volume;
    }

    private void ApplyMute(bool mute) {
        soundFX.mute = mute;
        if (bgMusic != null) bgMusic.mute = mute;
    }

    public void LandSound()     { soundFX.PlayOneShot(landClip); }
    public void IceBreakSound() { soundFX.PlayOneShot(iceBreakClip); }
    public void DeathSound()    { soundFX.PlayOneShot(deathClip); }
    public void GameOverSound() { soundFX.PlayOneShot(gameOverClip); }

    public float GetCurrentVolume() => soundFX.volume;
    public bool IsMuted() => soundFX.mute;

    public void ToggleMute(bool mute) {
        ApplyMute(mute);
        PlayerPrefs.SetInt("Muted", mute ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void AdjustSoundVolume(float volume) {
        ApplyVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
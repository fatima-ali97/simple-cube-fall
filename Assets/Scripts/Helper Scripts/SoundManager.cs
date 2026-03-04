using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip;

    void Awake() {
        if (instance == null)
            instance = this;
    }
    /*

    
        public float GetCurrentVolume()
        {
            return _audioSource.volume;
        }
    
        public bool IsMuted()
        {
            return _audioSource.mute;
        }
    
        public void ToggleMute(bool mute)
        {
            _audioSource.mute = mute;
        }
    
        public void AdjustSoundVolume(float volume)
        {
            _audioSource.volume = volume;
        }
    
    
    */
    public void LandSound() {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound() {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound() {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound() {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
    
    public float GetCurrentVolume()
    {
        return soundFX.volume;
    }
    
    public bool IsMuted()
    {
        return soundFX.mute;
    }
    
    public void ToggleMute(bool mute)
    {
        soundFX.mute = mute;
    }
    
    public void AdjustSoundVolume(float volume)
    {
        soundFX.volume = volume;
    }



}

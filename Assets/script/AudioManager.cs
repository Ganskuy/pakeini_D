using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;  // Audio source for sound effects
    public AudioClip buttonClickSound;               // Assign the click sound via Inspector

    // Play sound on button click
    public void PlayButtonClickSound()
    {
        if (sfxSource != null && buttonClickSound != null)
        {
            sfxSource.PlayOneShot(buttonClickSound); // Plays the sound once
        }
    }
}
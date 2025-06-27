using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void TocarSom(AudioClip clipeDeAudio)
    {
        if (clipeDeAudio != null)
        {
            audioSource.PlayOneShot(clipeDeAudio);
        }
    }
}
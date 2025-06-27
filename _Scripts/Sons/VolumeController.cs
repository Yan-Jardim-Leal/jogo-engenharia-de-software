using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderMusica;
    public Slider sliderSons;

    private const string MIXER_MUSICA = "VolumeMusica";
    private const string MIXER_SONS = "VolumeSom";

    private void Awake()
    {
        sliderMusica.onValueChanged.AddListener(SetVolumeMusica);
        sliderSons.onValueChanged.AddListener(SetVolumeSons);
    }

    private void Start()
    {
        sliderMusica.value = PlayerPrefs.GetFloat(MIXER_MUSICA, 1f);
        sliderSons.value = PlayerPrefs.GetFloat(MIXER_SONS, 1f);
    }

    public void SetVolumeMusica(float valor)
    {
        audioMixer.SetFloat(MIXER_MUSICA, Mathf.Log10(valor) * 20);
        PlayerPrefs.SetFloat(MIXER_MUSICA, valor);
    }

    public void SetVolumeSons(float valor)
    {
        audioMixer.SetFloat(MIXER_SONS, Mathf.Log10(valor) * 20);
        PlayerPrefs.SetFloat(MIXER_SONS, valor);
    }
}
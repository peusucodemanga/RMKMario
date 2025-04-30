using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
[SerializeField] private AudioMixer Mixer;
[SerializeField] private Slider VolumeSlider;
public void VolumeMusica(){
    float volume = VolumeSlider.value;
    Mixer.SetFloat("musica",volume);
}
}

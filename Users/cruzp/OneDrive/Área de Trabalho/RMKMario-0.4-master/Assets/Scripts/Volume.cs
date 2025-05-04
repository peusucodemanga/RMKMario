using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
[SerializeField] private AudioMixer Mixer;
[SerializeField] private Slider SoundTrackSlider,SFXslider;
public void VolumeSoundtrack(){
    float volume = SoundTrackSlider.value;
    Mixer.SetFloat("musica",volume);
}
public void VolumeSFX(){
    float volume2 = SFXslider.value;
    Mixer.SetFloat("SFX",volume2);
}
}

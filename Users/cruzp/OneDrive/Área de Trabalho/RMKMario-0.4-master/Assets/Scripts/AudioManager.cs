using UnityEngine;

public class SoundSFX : MonoBehaviour
{
[SerializeField]    AudioSource Soundtrack;
[SerializeField]    AudioSource SFX;

public AudioClip Background,FinalJogo,Morte,Pulo,MataG,GameOver,BlocoQuebrando;

    private void Start()
    {
        Soundtrack.clip = Background;
        Soundtrack.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFX.PlayOneShot(clip);
    }
    public void PararBack(){
        Soundtrack.Stop();
    }



}


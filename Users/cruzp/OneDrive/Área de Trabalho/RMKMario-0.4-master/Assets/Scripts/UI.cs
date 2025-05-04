using UnityEngine;
using TMPro;
using System;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerM,VidaM,PontoM;
    [SerializeField] int Vidas,Pontuacao;
    [SerializeField] GameObject GameOver;
    float tempoPassado;
    void Update()
    {

        //Atualizando Segundos
        tempoPassado+=Time.deltaTime;
        int segundos = Mathf.FloorToInt(tempoPassado);

        timerM.text=segundos.ToString("D4");
        if (tempoPassado>=9999) tempoPassado=0;
        //Atualizqndo vida do Mario
        Vidas=PlayerPrefs.GetInt("ContadorVida", 3);
        VidaM.text=Vidas.ToString();
        if(Vidas==0) GameOver.SetActive(true);
        //Pontuação
        Pontuacao=PlayerPrefs.GetInt("PontoM", 0);
        PontoM.text=Pontuacao.ToString("D4");

    }
}

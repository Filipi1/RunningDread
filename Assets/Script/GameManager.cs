using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager NewInstance;

    public TextMeshProUGUI txtTime;
    public int PlayerDeaths;

    private void Awake()
    {
        if (NewInstance == null)
            NewInstance = this;
        else if (NewInstance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        TempoSetup();
    }

    private void TempoSetup()
    {
        float Tempo = Time.time;

        string minutos = ((int)Tempo / 60).ToString();
        string segundos = (Tempo % 60).ToString("f0");

        if ((Tempo % 60) < 9.5f)
            txtTime.text = minutos + " : 0" + segundos;
        else
            txtTime.text = minutos + " : " + segundos;
    }
}

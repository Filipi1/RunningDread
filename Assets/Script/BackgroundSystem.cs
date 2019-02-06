using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSystem : MonoBehaviour
{
    public GameObject BGOne;
    public GameObject BGTwo;
    public Transform CameraPos;

    float newPos = 5.22f;
    float Counter = 1;
    float PosCamSave;

    void Update()
    {
        float posCam = CameraPos.transform.position.x;
        float CounterPros = Counter * 5.22f;

        if (posCam >= CounterPros) {
            if (Counter % 2 == 1) { 
                BGOne.transform.position = new Vector2(BGTwo.transform.position.x + newPos, BGTwo.transform.position.y);
                PosCamSave = posCam;
                Counter++;
            } else
            {
                BGTwo.transform.position = new Vector2(BGOne.transform.position.x + newPos, BGOne.transform.position.y);
                PosCamSave = posCam;
                Counter++;
            }
        }

        if (posCam < PosCamSave)
        {
            if (Counter % 2 == 1) {
                BGOne.transform.position = new Vector2(BGTwo.transform.position.x - newPos, BGTwo.transform.position.y);
                PosCamSave = posCam;
                Counter--;
            }
            else {
                BGTwo.transform.position = new Vector2(BGOne.transform.position.x - newPos, BGOne.transform.position.y);
                PosCamSave = posCam;
                Counter--;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject Block;
    public Transform BlockStarter;

    public int Gerador;
    float aleatorio;

    void Start()
    {
        
    }

    void Update() {
        if (Gerador < 36)
            WorldGenerator();
    }

    public void WorldGenerator() { 
        while (Gerador < 36) {
            aleatorio = Random.Range(1, 4);
            Debug.Log(aleatorio);
            switch (aleatorio) {
                case 1:
                    var Ground = Instantiate(Block, BlockStarter);
                    Ground.transform.parent = null;
                    BlockStarter.transform.position = new Vector2(Ground.transform.position.x + 0.15f, Ground.transform.position.y + 0.15f);
                    Gerador++;
                    break;
                case 2:
                    var Ground2 = Instantiate(Block, BlockStarter);
                    Ground2.transform.parent = null;
                    BlockStarter.transform.position = new Vector2(Ground2.transform.position.x + 0.15f, Ground2.transform.position.y);
                    Gerador++;
                    break;
                case 3:
                    var Ground3 = Instantiate(Block, BlockStarter);
                    Ground3.transform.parent = null;
                    BlockStarter.transform.position = new Vector2(Ground3.transform.position.x + 0.15f, Ground3.transform.position.y - 0.15f);
                    Gerador++;
                    break;
            }
        }
    }
}

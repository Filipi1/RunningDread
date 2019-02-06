using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform PlayerPos;

    void Update()
    {
        transform.position = new Vector3(PlayerPos.position.x, transform.position.y, -10);

        float CameraPos = transform.position.x;

        if (CameraPos <= 0)
            transform.position = new Vector3(0, transform.position.y, -10);
    }
}

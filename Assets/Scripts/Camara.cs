using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject john_idle_0;
    public Transform farBackground;
    public Transform middleBackground;

    private float lastXPos;

    void Start()
    {
        lastXPos = transform.position.x;
    }

    void Update()
    {
        if (john_idle_0 != null)
        {
            Vector3 position = transform.position;
            position.x = john_idle_0.transform.position.x;
            transform.position = position;

            float amountToMoveX = transform.position.x - lastXPos;

            farBackground.position = farBackground.position + new Vector3(amountToMoveX, 0f, 0f);
            middleBackground.position += new Vector3(amountToMoveX * .8f, 0f, 0f);

            lastXPos = transform.position.x;
        }
    }
}

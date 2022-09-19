using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller instance;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    public Sprite heartFull;
    public Sprite heartEmpty;
    public Sprite heartHalf;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateHealthDis()
    {
        switch(Movimiento.instance.CurrentHealth)
        {
            case 6:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;

                break;
            case 5:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartHalf;

                break;
            case 4:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartEmpty;

                break;
            case 3:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartHalf;
                Heart3.sprite = heartEmpty;

                break;
            case 2:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;
            case 1:
                Heart1.sprite = heartHalf;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;
            case 0:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;
            /*fault:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;
            */
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour

{
    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        img = GetComponent<Image>();
        int gameScore = gamemenager.gameScore;
        if (gameScore>0&& gameScore <= 1)
        {
            img.sprite = metalMedal;
        }else if (gameScore > 1 && gameScore <= 2)
        {
            img.sprite = bronzeMedal;
        }else if (gameScore > 2 && gameScore <= 3)
        {
            img.sprite = silverMedal;
        }
        else if (gameScore > 3)
        {
            img.sprite = goldMedal;
        }
    }
}

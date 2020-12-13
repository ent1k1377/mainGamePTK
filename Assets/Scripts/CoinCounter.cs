using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinCounterText;

    void Update()
    {
        coinCounterText.text = Convert.ToString(HeroMove.num_coins);
    }
}

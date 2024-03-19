using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private TMP_Text Cronometro;
    void Update()
    {
        Cronometro.text = "" + Time.deltaTime;
    }
}

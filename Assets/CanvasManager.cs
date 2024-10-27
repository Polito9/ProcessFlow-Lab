using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI minutesText;
    [SerializeField] private TextMeshProUGUI secondsText;

    private int minutes;
    private int seconds;

    private int timer;

    void Update()
    {
        timer = (int)TimerManager.Instance.getActualTime();

        minutes = timer / 60;
        seconds = timer % 60;

        minutesText.text = minutes.ToString();
        secondsText.text = seconds.ToString();

    }
}

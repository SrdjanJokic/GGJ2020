using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timer;

    private void Start()
    {
        StartCoroutine(Countdown());
    }
    public IEnumerator Countdown()
    {
        float timeLeft = 10;
        timer = GetComponent<Text>();
        while (timeLeft > 0)
        {
            timer.text = "Time: " + timeLeft-- + "s";
           
            yield return new WaitForSecondsRealtime(1);
        }
        if (timeLeft == 0)
        {
            timer.text = "Time's up!";
        }
        
    }
}

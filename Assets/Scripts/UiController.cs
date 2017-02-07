﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiController : MonoBehaviour
{
    GameController gc;
    public Slider timeSlider;
    public float timeToAnswer = 3f;
    float timer = 0f;
    public GameObject allRight;
    public GameObject noFault;
    public Text timeAndHalf;
    public Text matchResult;
    public Text currentPlayerScore;
    public Button whistleBtn;

    void Awake()
    {
        allRight.GetComponent<Text>().text = "Tutto regolare";
        noFault.GetComponent<Text>().text = "Cosa hai fischiato?";
        gc = FindObjectOfType<GameController>();
    }

    public bool isPushed;

    public void PushedButton()
    {
        isPushed = true;
    }

	public IEnumerator Timer()
    {
        isPushed = false;
        timer = 0;
        timeSlider.value = 1;
        while (timeSlider.value > 0f)
        {
            timer += Time.deltaTime;
            timeSlider.value = Mathf.Lerp(1,0, timer/timeToAnswer);
            yield return null;
        }
        gc.myTimerCo = null;

        if (!isPushed)
        {
            gc.CheckAnswer(false);
        }

	}
	
	void Update ()
    {
        if (gc.myTimerCo != null)
        {
            whistleBtn.interactable = true;
        }
        else
        {
            whistleBtn.interactable = false;
        }
	}
}
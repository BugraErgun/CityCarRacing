using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    CarSelection carSelection;

    [Header("Timer")]
    public int countDownTimer;

    [Header("Things To Stop")]
    public PlayerController playerController;
    public PlayerController playerController1;
    public OpponentCar opponentCar;
    public OpponentCar opponentCar1;
    public OpponentCar opponentCar2;
   
    

    public TextMeshProUGUI countDownText;


    private void Start()
    {
        StartCoroutine(TimeCount());
    }
    private void Update()
    {
        if (countDownTimer >1)
        {
            playerController.accelerationForce = 0f;
            playerController1.accelerationForce = 0f;
            opponentCar.movingSpeed= 0f;
            opponentCar1.movingSpeed = 0f;
            opponentCar2.movingSpeed = 0f;
            

        }
        else if (countDownTimer==0)
        {
            playerController.accelerationForce = 150;
            playerController1.accelerationForce = 150;
            opponentCar.movingSpeed = 10f;
            opponentCar1.movingSpeed = 9.5f;
            opponentCar2.movingSpeed = 9f;
           
        }
    }

    IEnumerator TimeCount()
    {
        while (countDownTimer > 0)
        {
            countDownText.text=countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;

        }
        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);

    }
}

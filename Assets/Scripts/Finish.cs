using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [Header("Finish UI")]
    public GameObject finishUI;
    public GameObject playerUI;
    public GameObject playerCar;

    [Header("Win/Lose Status")]
    public TextMeshProUGUI status;

    private void Start()
    {
        StartCoroutine(WaitForTheFinishUI());

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            StartCoroutine(FinishZoneTimer());
            status.text = "YOU WIN";
        }
        else if (other.gameObject.tag=="Enemy")
        {
            StartCoroutine(FinishZoneTimer());
            status.text = "YOU LOSE";
            status.color = Color.red;
        }
        
    }
    IEnumerator WaitForTheFinishUI()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    IEnumerator FinishZoneTimer()
    {
        finishUI.SetActive(true);
        playerUI.SetActive(false);
        playerCar.SetActive(false);

        yield return new WaitForSeconds(5);
        Time.timeScale = 0f;
    }
}

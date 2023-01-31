using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    

    [Header("Buttons and Canvas")]
    public Button nextButton;
    public Button prevButton;

    [Header("Buttons and Canvas")]
    public GameObject selectionCanvas;
    public GameObject skipButton;
    public GameObject playButton;


    private int currentCar;
    private GameObject[] carList;

    

    private void Awake()
    {
        
      
        ChooseCar(0);
    }
    private void Start()
    {
        currentCar = PlayerPrefs.GetInt("CarSelected");

        carList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject item in carList)
        {
            item.SetActive(false);
        }
        if (carList[currentCar])
        {
            carList[currentCar].SetActive(true);
        }
       
    }
    private void ChooseCar(int index)
    {
        prevButton.interactable = (currentCar != 0);
        nextButton.interactable = (currentCar != transform.childCount-1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }

    }
    public void SwitchCar(int switchCars)
    {
        currentCar += switchCars;
        ChooseCar(currentCar);
       

    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("CarSelected", currentCar);
        SceneManager.LoadScene(1);
        selectionCanvas.SetActive(true);
        playButton.SetActive(true);
    }
  
}

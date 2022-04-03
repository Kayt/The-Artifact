using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBackpack : MonoBehaviour
{
    public int maxNumberOfFruitsToStore = 50;
    public int currentNumberOfStoredFruits;

    [SerializeField]
    private Text backPackIntoText;


    private void Start()
    {
        SetBackpackInfoText(0);
    }

    public void AddFruits(int amount)
    {
        currentNumberOfStoredFruits += amount;
        if (currentNumberOfStoredFruits > maxNumberOfFruitsToStore)
            currentNumberOfStoredFruits = maxNumberOfFruitsToStore;

        SetBackpackInfoText(currentNumberOfStoredFruits);
    }

    public int TakeFruits()
    {
        int takenFruits = currentNumberOfStoredFruits;
        currentNumberOfStoredFruits = 0;

        SetBackpackInfoText(currentNumberOfStoredFruits);

        return takenFruits;
    }


    void SetBackpackInfoText(int amount)
    {
        backPackIntoText.text = "Backpack: " + amount + "/" + maxNumberOfFruitsToStore;
    }


} // class 

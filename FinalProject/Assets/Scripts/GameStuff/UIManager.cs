using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI ELEMENTS")]
    [SerializeField] private Image staminaBar;

    [SerializeField] private TextMeshProUGUI goalText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateStaminaBar(float stamina)
    {
        staminaBar.fillAmount = stamina / 5;
    }

    public void UpdateGoalText(int currentStages, int maxStages)
    {
        if (currentStages == maxStages)
        {
            goalText.text = "All cats collected! Go back to car!";
        }
        else
        {
            goalText.text = "Cats Collected: " + currentStages.ToString() + "/" + maxStages.ToString();
        }
    }
}
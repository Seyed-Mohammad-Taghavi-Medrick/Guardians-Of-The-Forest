using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private float baseLives = 3;
    private float lives;
    private Text livesText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("Diffculty setting currently is " + PlayerPrefsController.GetDifficulty());
    }


    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLives()
    {
        lives -= 1;
        UpdateDisplay();
        if (lives <= 0) ;
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
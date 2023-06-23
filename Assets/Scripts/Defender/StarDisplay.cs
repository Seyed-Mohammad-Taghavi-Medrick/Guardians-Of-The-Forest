using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 1000;
    private Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnouphStar(int amount)
    {
        return stars >= amount;
    }

    public void AddStars (int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    
    public void SpendStars (int amount)
    {
        if (amount <= stars)
        {
            stars -= amount;
            UpdateDisplay();
            
        }
    }
}
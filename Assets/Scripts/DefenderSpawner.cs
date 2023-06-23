using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
   public Defender defender;
   private GameObject defenderParent;

   private void Start()
   {
       CreatDefender();
   }

   private void CreatDefender()
   {
       defenderParent = GameObject.Find("Defender");
   }
   private void OnMouseDown()
    {
        AttemtToPlaceDefebnderAt(GetsquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemtToPlaceDefebnderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defendrCost = defender.GetStarCost();
        
        if (starDisplay.HaveEnouphStar(defendrCost))
        {
            Spawandefender(gridPos);
            starDisplay.SpendStars(defendrCost);
        }
    }
    
    private Vector2 GetsquareClicked()
    {
        Vector2 clickedPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickedPos);
        Vector2 gidedPos = SnapTOGrid(worldPos);
        return gidedPos;
    }

    private Vector2 SnapTOGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void Spawandefender(Vector2 wordPos)
    {
        Defender newDefender = Instantiate(defender, wordPos, transform.rotation) as Defender;
    }
}
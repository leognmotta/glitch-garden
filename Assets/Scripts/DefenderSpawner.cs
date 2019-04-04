using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    Defender defender;

    private void OnMouseDown() {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect) {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition) {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        if (defender) {
            int defenderCost = defender.GetStarCost();
            if (StarDisplay.HaveEnoughStars(defenderCost)) {
                SpawnDefender(gridPosition);
                StarDisplay.SpendStars(defenderCost);
            }
        }
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 worldPos) {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPosition) {
        Defender newDefender = Instantiate(defender, roundedPosition, transform.rotation);
    }
}
using UnityEngine;

public class SecondFloorPit : Pit {
    public Transform firstFloorLadder,
        secondFloorLadder;

    public override Vector3 GetFallLocation()
    {
        Vector3 pitPosition = pitTransform.position;
        if (Mathf.Approximately(pitTransform.localScale.x, -1f))
        {
            pitPosition.x -= 1;
        }

        Vector3 directionVector = pitPosition - secondFloorLadder.position;
        return firstFloorLadder.position + directionVector;
    }
}

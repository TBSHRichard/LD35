using UnityEngine;

public class TPRightClickAction : RightClickAction {
    public Transform tpLocation;

    public override void Action(Player player)
    {
        player.transform.position = tpLocation.position;
    }
}

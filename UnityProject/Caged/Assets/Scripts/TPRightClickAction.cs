using UnityEngine;

public class TPRightClickAction : RightClickAction {
    public Transform tpLocation;
    public Room tpRoom;

    public override void Action(Player player)
    {
        player.Teleport(tpLocation.position, tpRoom);
    }
}

using UnityEngine;

public class DoorRightClickAction : RightClickAction
{
    public GameObject door;
    public Animator doorAnimator;
    public Transform tpLocation;
    public Room tpRoom;
    public AudioSource openSound;

    public override void ActionCommand(Player player)
    {
        openSound.Play();

        TPRightClickAction tpAction = door.AddComponent<TPRightClickAction>();
        tpAction.tpLocation = tpLocation;
        tpAction.tpRoom = tpRoom;
        player.SetRightClickAction(tpAction);
        player.UseKey();

        doorAnimator.SetTrigger("Open");

        Destroy(this);
    }

    public override bool CanAct(Player player)
    {
        return player.numberOfKeys > 0;
    }
}

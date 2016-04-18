using UnityEngine;

public class TwigRightClickAction : RightClickAction {
    public Animator twigAnimator;

    public override void ActionCommand(Player player)
    {
        Mute(player);
        twigAnimator.SetTrigger("Destroy");
    }

    public override bool CanAct(Player player)
    {
        return player.form == AnimalForm.Lion;
    }
}

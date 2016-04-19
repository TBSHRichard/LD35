using UnityEngine;

public class LeverRightClickAction : RightClickAction {
    public LeverObject[] connectedObjects;
    public Animator leverAnimator;
    public AudioSource leverToggle;

    private bool _isOn;

    public override void ActionCommand(Player player)
    {
        _isOn = !_isOn;
        leverAnimator.SetBool("IsOn", _isOn);
        leverToggle.Play();

        foreach (LeverObject leverObject in connectedObjects)
        {
            leverObject.Toggle();
        }
    }

    public override bool CanAct(Player player)
    {
        return player.form == AnimalForm.Snake;
    }
}

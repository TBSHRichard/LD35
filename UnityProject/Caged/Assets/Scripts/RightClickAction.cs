﻿using UnityEngine;

public abstract class RightClickAction : MonoBehaviour {
    public abstract void ActionCommand(Player player);

    private bool _isMuted;

    void Start()
    {
        _isMuted = false;
    }

    /*
        Perform the associated action if the Player is in the right form.
    */
    public void Action(Player player)
    {
        if (RequiredForm() == AnimalForm.Any || RequiredForm() == player.form)
        {
            ActionCommand(player);
        }
    }

    /*
        Returns the AnimalForm the Player needs to be in to activate this
        action.
    */
    public virtual AnimalForm RequiredForm()
    {
        return AnimalForm.Any;
    }

    /*
        Show the Player's right click helper if he/she is in the right form.
    */
    public void UpdateHelper(Player player)
    {
        if (RequiredForm() == AnimalForm.Any || RequiredForm() == player.form)
        {
            player.ShowHelper();
        }
        else
        {
            player.HideHelper();
        }
    }

    /*
        Mutes this RightClickAction so it cannot be triggered.
    */
    protected void Mute(Player player)
    {
        _isMuted = true;
        player.HideHelper();
        player.RemoveRightClickAction();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isMuted && other.tag == "Player")
        {
            UpdateHelper(other.GetComponent<Player>());
            other.GetComponent<Player>().SetRightClickAction(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().HideHelper();
            other.GetComponent<Player>().RemoveRightClickAction();
        }
    }
}

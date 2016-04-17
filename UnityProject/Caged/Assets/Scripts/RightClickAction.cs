using UnityEngine;

public abstract class RightClickAction : MonoBehaviour {
    public abstract void Action(Player player);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().ShowHelper();
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

using UnityEngine;
using UnityEngine.UI;

public class TransformButton : MonoBehaviour {
    public Image iconImage;
    public Sprite animalIcon;
    public Player player;
    public AnimalForm shapeshiftForm;

    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
    }

    /*
        Unlock the button so it may be clicked.
    */
    public void Unlock()
    {
        _button.interactable = true;
        iconImage.sprite = animalIcon;
    }

    /*
        Transform the Player into the animal associated with this
        button.
    */
    public void Transform()
    {
        player.Shapeshift(shapeshiftForm);
    }
}


using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    Level level;

    [SerializeField]
    GameObject lockGameObject;
    [SerializeField]
    Button levelButton;
    public bool locked;


    public void Initialize(bool locked_)
    {
        locked = locked_;
        if(locked)
        {
            lockGameObject.SetActive(true);
            levelButton.interactable = false;
        }
        else
        {
            lockGameObject.SetActive(false);
            levelButton.interactable = true;
        }
    }

    public void Select()
    {
        FindObjectOfType<LevelSelectionDirector>().SelectLevel(level);
    }
}

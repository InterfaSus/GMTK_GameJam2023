using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ButtonSprites
{
    public Button button;
    public Sprite spriteUp;
    public Sprite spriteDown;
}

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    public ButtonSprites[] categoryButtonSprites;
    public ButtonSprites[] tabButtonSprites;


    void Awake()
    {
        instance = this;
    }

    public void SetActiveCategoryButton(int activeButtonIndex)
    {
        for (int i = 0; i < categoryButtonSprites.Length; i++)
        {
            ButtonSprites bs = categoryButtonSprites[i];
            bs.button.image.sprite = i == activeButtonIndex ? bs.spriteDown : bs.spriteUp;
        }
    }

    public void SetActiveTabButton(int activeButtonIndex)
    {
        for (int i = 0; i < tabButtonSprites.Length; i++)
        {
            ButtonSprites bs = tabButtonSprites[i];
            if (i == activeButtonIndex)
            {
                // Si este botón ya está activo, desactívalo
                if (bs.button.image.sprite == bs.spriteDown) 
                {
                    bs.button.image.sprite = bs.spriteUp;
                }
                // Si este botón no está activo, actívalo y desactiva los demás
                else
                {
                    foreach (ButtonSprites otherButton in tabButtonSprites)
                    {
                        otherButton.button.image.sprite = otherButton.spriteUp;
                    }
                    bs.button.image.sprite = bs.spriteDown;
                }
            }
        }
    }
}
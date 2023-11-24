using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextFoodDisplay : MonoBehaviour
{
    public Image nextFoodImage;

    void Start()
    {
        // Initially, turn off the visibility of the nextFoodImage
        nextFoodImage.enabled = false;
    }

    public void SetNextFoodSprite(Sprite sprite)
    {
        // Set the sprite
        nextFoodImage.sprite = sprite;

        // Turn on the visibility when setting the sprite
        nextFoodImage.enabled = true;
    }

}

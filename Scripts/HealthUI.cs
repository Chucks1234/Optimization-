using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    // public PlayerHealth HP
    // Originally from PlayerHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    bool damaged;

    private void Update()
    {      //When our character takes damage
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
}

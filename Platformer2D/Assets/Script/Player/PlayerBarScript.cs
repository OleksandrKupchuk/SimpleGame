using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarScript : MonoBehaviour
{
    [SerializeField] Image imageHealth;
    [SerializeField] Text textPlayer;
    [SerializeField] private float currentFillAmountHealth;

    [SerializeField] Image imageExperience;
    [SerializeField] Text textExperience;
    [SerializeField] private float currentFillAmountExperience;

    [SerializeField] Text textPlayerLevel;

    // Start is called before the first frame update
    void Start()
    {
        textPlayer.text = "Health : " + Player.PlayerInstance.Health;
        textExperience.text = Player.PlayerInstance.CurrentExperience + " : " + Player.PlayerInstance.MaxExperienceInCurrentLevel;
        textPlayerLevel.text = "LVL : " + Player.PlayerInstance.playerCurrentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        textPlayer.text = "Health : " + Player.PlayerInstance.Health;
        imageHealth.fillAmount = CurrentFillAmountHealth();

        textExperience.text = Player.PlayerInstance.CurrentExperience + " : " + Player.PlayerInstance.MaxExperienceInCurrentLevel;
        imageExperience.fillAmount = CurrentFillAmountExperience();

        textPlayerLevel.text = Player.PlayerInstance.playerCurrentLevel + "";
    }

    private float CurrentFillAmountHealth()
    {
        return currentFillAmountHealth = (Player.PlayerInstance.Health / Player.PlayerInstance.PlayerMaxHealth);
    }

    private float CurrentFillAmountExperience()
    {
        return currentFillAmountExperience = (float)Player.PlayerInstance.CurrentExperience / (float)Player.PlayerInstance.MaxExperienceInCurrentLevel;
    }
}

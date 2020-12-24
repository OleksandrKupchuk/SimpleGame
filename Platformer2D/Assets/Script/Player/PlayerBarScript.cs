using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarScript : MonoBehaviour
{
    [SerializeField] Image imageHealth;
    [SerializeField] Text textPlayer;
    private float currentFillAmountHealth;

    [SerializeField] Image imageExperience;
    [SerializeField] Text textExperience;
    private float currentFillAmountExperience;

    [SerializeField] Text textPlayerLevel;

    void Start()
    {
        textPlayer.text = "Health : " + Player.Instance.PlayerHealth;
        textExperience.text = Player.Instance.PlayerCurrentExperience + " : " + Player.Instance.PlayerMaxExperienceInCurrentLevel;
        textPlayerLevel.text = "LVL : " + Player.Instance.playerCurrentLevel;
    }

    void Update()
    {
        textPlayer.text = "Health : " + Player.Instance.PlayerHealth;
        imageHealth.fillAmount = CurrentFillAmountHealth();

        textExperience.text = Player.Instance.PlayerCurrentExperience + " : " + Player.Instance.PlayerMaxExperienceInCurrentLevel;
        imageExperience.fillAmount = CurrentFillAmountExperience();

        textPlayerLevel.text = Player.Instance.playerCurrentLevel + "";
    }

    private float CurrentFillAmountHealth()
    {
        return currentFillAmountHealth = (Player.Instance.PlayerHealth / Player.Instance.maxHealth);
    }

    private float CurrentFillAmountExperience()
    {
        return currentFillAmountExperience = (float)Player.Instance.PlayerCurrentExperience / (float)Player.Instance.PlayerMaxExperienceInCurrentLevel;
    }
}

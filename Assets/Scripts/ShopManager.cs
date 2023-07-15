using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class ShopManager : MonoBehaviour
{
    public Stats stats;

    public GameObject[] buttons;
    public TextMeshProUGUI[] levels;
    public TextMeshProUGUI[] costs;
    public TextMeshProUGUI pointsText;
    
    [SerializeField]
    [Tooltip("Cost of upgrading memory")]
    public int[] memoryUpgradeCosts;

    [SerializeField]
    [Tooltip("Cost of upgrading focus")]
    public int[] focusUpgradeCosts;

    [SerializeField]
    [Tooltip("Cost of upgrading anti-spam")]
    public int[] antiSpamUpgradeCosts;

    [SerializeField] 
    [Tooltip("Cost of upgrading time speed")]
    public int[] timeUpgradeCosts;


    [SerializeField]
    [Tooltip("Cost of upgrading load time")]
    public int[] loadTimeUpgradeCosts;

    private int[] upgradeLevels = new int[5];

    private int memoryUpgradeLevel = 0;
    private int focusUpgradeLevel = 0;
    private int antiSpamUpgradeLevel = 0;
    private int timeUpgradeLevel = 0;
    private int loadTimeUpgradeLevel = 0;
    

    public void UpdateShop() {

        pointsText.text = "Points: " + Persistents.currentScore.ToString();
    }

    void Start()
    {   
        memoryUpgradeLevel = Persistents.upgradeLevels[0];
        focusUpgradeLevel = Persistents.upgradeLevels[1];
        antiSpamUpgradeLevel = Persistents.upgradeLevels[2];
        timeUpgradeLevel = Persistents.upgradeLevels[3];
        loadTimeUpgradeLevel = Persistents.upgradeLevels[4];

        upgradeLevels[0] = memoryUpgradeLevel;
        upgradeLevels[1] = focusUpgradeLevel;
        upgradeLevels[2] = antiSpamUpgradeLevel;
        upgradeLevels[3] = timeUpgradeLevel;
        upgradeLevels[4] = loadTimeUpgradeLevel;

        costs[0].text = memoryUpgradeLevel < memoryUpgradeCosts.Length ? memoryUpgradeCosts[memoryUpgradeLevel].ToString() + " Points" : "";
        costs[1].text = focusUpgradeLevel < focusUpgradeCosts.Length ? focusUpgradeCosts[focusUpgradeLevel].ToString() + " Points" : "";
        costs[2].text = antiSpamUpgradeLevel < antiSpamUpgradeCosts.Length ? antiSpamUpgradeCosts[antiSpamUpgradeLevel].ToString() + " Points" : "";
        costs[3].text = timeUpgradeLevel < timeUpgradeCosts.Length ? timeUpgradeCosts[timeUpgradeLevel].ToString() + " Points" : "";
        costs[4].text = loadTimeUpgradeLevel < loadTimeUpgradeCosts.Length ? loadTimeUpgradeCosts[loadTimeUpgradeLevel].ToString() + " Points" : "";

        pointsText.text = "Points:" + Persistents.currentScore.ToString();

        for (int i = 0; i < upgradeLevels.Length; i++)
        {
            levels[i].text = upgradeLevels[i].ToString();
        }
    }

    void Update()
    {
        if (memoryUpgradeLevel == memoryUpgradeCosts.Length)
            buttons[0].SetActive(false);

        if (focusUpgradeLevel == focusUpgradeCosts.Length)
            buttons[1].SetActive(false);

        if (antiSpamUpgradeLevel == antiSpamUpgradeCosts.Length)
            buttons[2].SetActive(false);

        if (timeUpgradeLevel == timeUpgradeCosts.Length)
            buttons[3].SetActive(false);
        
        if (loadTimeUpgradeLevel == loadTimeUpgradeCosts.Length)
            buttons[4].SetActive(false);
    }
    
    IEnumerator BlinkText()
    {
        float duration = 0.1f;

        Color originalColor = pointsText.color;

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            pointsText.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            pointsText.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }

        pointsText.color = originalColor;
    }

#region Upgrades

    public void IncreaseMemory()
    {
        if (memoryUpgradeCosts[memoryUpgradeLevel] <= Persistents.currentScore)
        {
            Persistents.currentScore -= memoryUpgradeCosts[memoryUpgradeLevel];
            pointsText.text = "Points:" + Persistents.currentScore.ToString();
            
            memoryUpgradeLevel++;

            if(memoryUpgradeLevel < memoryUpgradeCosts.Length)
            upgradeLevels[0] = memoryUpgradeLevel;
            Persistents.upgradeLevels[0] = memoryUpgradeLevel;

            levels[0].text = memoryUpgradeLevel.ToString();

            if(memoryUpgradeLevel < memoryUpgradeCosts.Length)
            costs[0].text = memoryUpgradeCosts[memoryUpgradeLevel].ToString() + " Points";

            stats.memory += 1;
        }
        else
        {
            StartCoroutine(BlinkText());
        }
    }

    public void IncreaseFocus(float amount)
    {
        if (focusUpgradeCosts[focusUpgradeLevel] <= Persistents.currentScore)
        {
            Persistents.currentScore -= focusUpgradeCosts[focusUpgradeLevel];
            pointsText.text = "Points:" + Persistents.currentScore.ToString();

            focusUpgradeLevel++;

            if(focusUpgradeLevel < focusUpgradeCosts.Length)
            upgradeLevels[1] = focusUpgradeLevel;
            Persistents.upgradeLevels[1] = focusUpgradeLevel;

            levels[1].text = focusUpgradeLevel.ToString();

            if(focusUpgradeLevel < focusUpgradeCosts.Length)
            costs[1].text = focusUpgradeCosts[focusUpgradeLevel].ToString() + " Points";

            stats.focus += amount;
        }
        else
        {
            StartCoroutine(BlinkText());
        }
    }

    public void IncreaseAntiSpam(float amount)
    {
        if (antiSpamUpgradeCosts[antiSpamUpgradeLevel] <= Persistents.currentScore)
        {
            Persistents.currentScore -= antiSpamUpgradeCosts[antiSpamUpgradeLevel];
            pointsText.text = "Points:" + Persistents.currentScore.ToString();

            antiSpamUpgradeLevel++;

            if(antiSpamUpgradeLevel < antiSpamUpgradeCosts.Length)
            upgradeLevels[2] = antiSpamUpgradeLevel;
            Persistents.upgradeLevels[2] = antiSpamUpgradeLevel;

            levels[2].text = antiSpamUpgradeLevel.ToString();

            if(antiSpamUpgradeLevel < antiSpamUpgradeCosts.Length)
            costs[2].text = antiSpamUpgradeCosts[antiSpamUpgradeLevel].ToString() + " Points";

            stats.antiSpam += amount;
        }
        else
        {
            StartCoroutine(BlinkText());
        }
    }

    public void DecreaseTimeSpeed(float amount)
    {
        if (timeUpgradeCosts[timeUpgradeLevel] <= Persistents.currentScore)
        {
            Persistents.currentScore -= timeUpgradeCosts[timeUpgradeLevel];
            pointsText.text = "Points:" + Persistents.currentScore.ToString();

            timeUpgradeLevel++;

            if(timeUpgradeLevel < timeUpgradeCosts.Length)
            upgradeLevels[3] = timeUpgradeLevel;
            Persistents.upgradeLevels[3] = timeUpgradeLevel;

            levels[3].text = timeUpgradeLevel.ToString();

            if(timeUpgradeLevel < timeUpgradeCosts.Length)
            costs[3].text = timeUpgradeCosts[timeUpgradeLevel].ToString() + " Points";

            stats.timeSpeed -= amount;
        }
        else
        {
            StartCoroutine(BlinkText());
        }
    }
    public void DecreaseLoadTime(float amount)
    {
        if (loadTimeUpgradeCosts[loadTimeUpgradeLevel] <= Persistents.currentScore)
        {
            Persistents.currentScore -= loadTimeUpgradeCosts[loadTimeUpgradeLevel];
            pointsText.text = "Points:" + Persistents.currentScore.ToString();

            loadTimeUpgradeLevel++;

            if(loadTimeUpgradeLevel < loadTimeUpgradeCosts.Length)
            upgradeLevels[4] = loadTimeUpgradeLevel;
            Persistents.upgradeLevels[4] = loadTimeUpgradeLevel;

            levels[4].text = loadTimeUpgradeLevel.ToString();

            if(loadTimeUpgradeLevel < loadTimeUpgradeCosts.Length)
            costs[4].text = loadTimeUpgradeCosts[loadTimeUpgradeLevel].ToString() + " Points";

            stats.loadTime -= amount;
        }
        else
        {
            StartCoroutine(BlinkText());
        }
    }
#endregion
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected WeaponDataScriptableObject weaponData;
    [SerializeField] private UpgradeUIElement upgradeUIElement;
    [SerializeField] private PlayerResourceManager playerResourceManager;

    protected int currentUpgradeStage = -1;

    protected int maxUpgradeStage;
    protected bool isEnabled = false;

    protected virtual void Start()
    {
        maxUpgradeStage = weaponData.stagesSOs.GetLength(0);
        UpdateUIElement();
    }

    protected virtual void Upgrade()
    {
        if (playerResourceManager.CanGetResources(weaponData.stagesSOs[currentUpgradeStage + 1]) && currentUpgradeStage < maxUpgradeStage - 1)
        {
            currentUpgradeStage++;
            UpdateUIElement();
        }
        else
        {
            Debug.Log("Cannot upgrade");
        }
    }

    private void UpdateUIElement()
    {
        upgradeUIElement.Setup(weaponData.stagesSOs[currentUpgradeStage + 1]);
    }
}

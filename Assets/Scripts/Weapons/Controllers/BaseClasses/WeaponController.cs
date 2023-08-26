using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] protected WeaponDataScriptableObject weaponData;
    [SerializeField] private UpgradeUIElement upgradeUIElement;

    protected int currentUpgradeStage = 0;

    protected int maxUpgradeStage;

    protected virtual void Start()
    {
        maxUpgradeStage = weaponData.stagesSOs.GetLength(0);
        UpdateUIElement();
    }

    protected virtual void Upgrade()
    {
        if (currentUpgradeStage < maxUpgradeStage - 1)
        {
            currentUpgradeStage++;
            UpdateUIElement();
        }
    }

    private void UpdateUIElement()
    {
        upgradeUIElement.Setup(weaponData.stagesSOs[currentUpgradeStage]);
    }
}

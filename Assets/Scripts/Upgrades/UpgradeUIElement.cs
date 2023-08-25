using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUIElement : MonoBehaviour
{
    [SerializeField] private Image upgradeIcon;
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI resource1AmountText;
    [SerializeField] private TextMeshProUGUI resource2AmountText;
    [SerializeField] private TextMeshProUGUI resource3AmountText;
    [SerializeField] private TextMeshProUGUI resource4AmountText;

    public void Setup(UpgradeStageScriptableObject upgradeStage)
    {
        upgradeIcon.sprite = upgradeStage.upgradeIcon;
        upgradeText.text = upgradeStage.upgradeText;

        resource1AmountText.text = upgradeStage.resource1Amount.ToString();
        resource2AmountText.text = upgradeStage.resource2Amount.ToString();
        resource3AmountText.text = upgradeStage.resource3Amount.ToString();
        resource4AmountText.text = upgradeStage.resource4Amount.ToString();
    }
}

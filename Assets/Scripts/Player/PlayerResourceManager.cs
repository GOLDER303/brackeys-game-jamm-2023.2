using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerResourceManager : MonoBehaviour
{
    public static Action<Resource> OnResourceCollected;

    [SerializeField] private TextMeshProUGUI resource1OwnedAmount;
    [SerializeField] private TextMeshProUGUI resource2OwnedAmount;
    [SerializeField] private TextMeshProUGUI resource3OwnedAmount;
    [SerializeField] private TextMeshProUGUI resource4OwnedAmount;

    public Dictionary<string, int> ResourcesHeld => resourcesHeld;

    private readonly Dictionary<string, int> resourcesHeld = new();

    void Start()
    {
        resourcesHeld.Add("Resource1", 0);
        resourcesHeld.Add("Resource2", 0);
        resourcesHeld.Add("Resource3", 0);
        resourcesHeld.Add("Resource4", 0);

        UpdateUI();
    }

    public bool CanGetResources(UpgradeStageScriptableObject upgradeStageSO)
    {
        if (resourcesHeld["Resource1"] < upgradeStageSO.resource1Amount ||
            resourcesHeld["Resource2"] < upgradeStageSO.resource2Amount ||
            resourcesHeld["Resource3"] < upgradeStageSO.resource3Amount ||
            resourcesHeld["Resource4"] < upgradeStageSO.resource4Amount)
        {
            return false;
        }

        resourcesHeld["Resource1"] -= upgradeStageSO.resource1Amount;
        resourcesHeld["Resource2"] -= upgradeStageSO.resource2Amount;
        resourcesHeld["Resource3"] -= upgradeStageSO.resource3Amount;
        resourcesHeld["Resource4"] -= upgradeStageSO.resource4Amount;

        UpdateUI();

        return true;
    }

    private void UpdateUI()
    {
        resource1OwnedAmount.text = resourcesHeld["Resource1"].ToString();
        resource2OwnedAmount.text = resourcesHeld["Resource2"].ToString();
        resource3OwnedAmount.text = resourcesHeld["Resource3"].ToString();
        resource4OwnedAmount.text = resourcesHeld["Resource4"].ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Resource"))
        {
            Resource resource = other.GetComponent<Resource>();
            string resourceName = resource.ResourceName;

            resourcesHeld[resourceName]++;

            OnResourceCollected?.Invoke(resource);

            UpdateUI();

            Destroy(other.gameObject);
        }
    }

}

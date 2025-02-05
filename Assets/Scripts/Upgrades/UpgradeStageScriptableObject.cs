using UnityEngine;

[CreateAssetMenu()]
public class UpgradeStageScriptableObject : ScriptableObject
{
    public int resource1Amount;
    public int resource2Amount;
    public int resource3Amount;
    public int resource4Amount;

    public float damage;
    public float cooldown;
    public float speed;
    public int count;
}

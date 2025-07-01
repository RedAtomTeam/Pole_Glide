using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsConfig", menuName = "Scriptable Objects/StatsConfig")]
public class StatsConfig : ScriptableObject
{
    public List<LevelConfig> levelConfigs;
    public int distance;
}

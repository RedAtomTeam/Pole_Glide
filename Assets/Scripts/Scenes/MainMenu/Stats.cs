using System.Linq;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private StatsConfig _config;

    [SerializeField] private TextMeshProUGUI _levelsText;
    [SerializeField] private TextMeshProUGUI _distanceText;


    private void OnEnable()
    {
        _levelsText.text = (_config.levelConfigs.Where(e => e.status == true)).ToArray().Length.ToString();
        _distanceText.text = _config.distance.ToString();
    }
}

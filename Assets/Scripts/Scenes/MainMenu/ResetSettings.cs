using UnityEngine;
using UnityEngine.UI;

public class ResetSettings : MonoBehaviour
{
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderEffects;

    private AudioService _audioService;


    private void Awake()
    {
        _audioService = AudioService.Instance;
        GetComponent<Button>().onClick.AddListener(() =>
        {
            _sliderMusic.value = 1f;
            _sliderEffects.value = 1f;
        });
    }


}

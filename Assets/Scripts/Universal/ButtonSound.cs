using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private AudioService _audioService;


    private void Start()
    {
        _audioService = AudioService.Instance;
        GetComponent<Button>().onClick.AddListener(() => { 
            _audioService.PlayEffect(_clip); });
    }


}

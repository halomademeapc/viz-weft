using UnityEngine;

public class AudioAnalyzer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private float[] _audioSpectrum = new float[128];
    public float SpectrumValue { get; private set; }

    private void Start()
    {
        var device = Microphone.devices[0];
        Debug.Log($"Using microphone {device}");
        audioSource.clip = Microphone.Start(device, true, 1, 44100);
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        audioSource.GetSpectrumData(_audioSpectrum, 0, FFTWindow.BlackmanHarris);

        if (_audioSpectrum != null && _audioSpectrum.Length > 0)
            SpectrumValue = _audioSpectrum[0];
    }
}

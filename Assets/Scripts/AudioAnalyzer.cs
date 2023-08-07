using UnityEngine;

public class AudioAnalyzer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private float[] _audioSpectrum = new float[128];
    public float SpectrumValue { get; private set; }

    void Update()
    {
        audioSource.GetSpectrumData(_audioSpectrum, 0, FFTWindow.BlackmanHarris);

        if (_audioSpectrum != null && _audioSpectrum.Length > 0)
            SpectrumValue = _audioSpectrum[0];
    }
}

using System.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShakeBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _maxGain;
    [SerializeField]
    private CinemachineImpulseListener _listener;
    private CinemachineImpulseSource _impulseSource;

    private void Awake()
    {
        TryGetComponent(out _impulseSource);
        _listener.Gain = 0.2f;    
    }

    public async Task CameraShake(DetectionBehaviour obj)
    {
        await Task.Yield();
        float currentTime = 0f;

        _listener.Gain = 0.3f;

        while (!obj.IsFind && obj.StartDetectTime != 0)
        {
            currentTime += Time.deltaTime;
            if (_listener.Gain < _maxGain) _listener.Gain = currentTime * 10f;

            _impulseSource.GenerateImpulse();

            await Task.Delay((int)(_impulseSource.ImpulseDefinition.ImpulseDuration * 1000f));
        }

        _listener.Gain = 0f;
    }
}

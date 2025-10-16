using System.Threading.Tasks;
using UnityEngine;

public class ObjectCollectedBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _darkness;
    [SerializeField] private GameObject _nextLevel;

    private CameraShakeBehaviour _shake;
    private Task _shakeTask;

    private void Awake()
    {
        TryGetComponent(out _shake);
        DetectionBehaviour.OnObjectFound += ObjectCollected;
        DetectionBehaviour.OnObjectWaiting += WaitForCollection;
        DetectionBehaviour.OnObjectSaveLoaded += ObjectSaveLoaded;
    }

    private void WaitForCollection(DetectionBehaviour obj) // add feedbacks.
    {
        _shakeTask = _shake.CameraShake(obj);
    }

    private void ObjectCollected(DetectionBehaviour obj) // add feedbacks.
    {
        if (obj.IsProgramm)
        {
            _darkness.SetActive(false);
            _nextLevel.SetActive(true);
        }

        else obj.gameObject.SetActive(false);
    }

    private void ObjectSaveLoaded(DetectionBehaviour obj, bool found)
    {
        if (found)
        {
            if (obj.IsProgramm)
            {
                _darkness.SetActive(false);
                _nextLevel.SetActive(true);
            }

            else obj.gameObject.SetActive(false);
        }

        else if (obj.IsProgramm)
        {
            _darkness.SetActive(true);
            _nextLevel.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if(_shakeTask != null) _shakeTask = null;

        DetectionBehaviour.OnObjectFound -= ObjectCollected;
        DetectionBehaviour.OnObjectWaiting -= WaitForCollection;
        DetectionBehaviour.OnObjectSaveLoaded -= ObjectSaveLoaded;
    }
}

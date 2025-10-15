using UnityEngine;

public class ObjectCollectedBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _darkness;

    private void Awake()
    {
        DetectionBehaviour.OnObjectFound += ObjectCollected;
        DetectionBehaviour.OnObjectWaiting += WaitForCollection;
        DetectionBehaviour.OnObjectSaveLoaded += ObjectSaveLoaded;
    }

    private void WaitForCollection(DetectionBehaviour obj) // add feedbacks.
    {
        obj.transform.localScale *= 1.1f;
    }

    private void ObjectCollected(DetectionBehaviour obj) // add feedbacks.
    {
        if(obj.IsProgramm) _darkness.SetActive(false);
        else obj.gameObject.SetActive(false);
    }

    private void ObjectSaveLoaded(DetectionBehaviour obj, bool found)
    {
        if(found)
        {
            if(obj.IsProgramm) _darkness.SetActive(false);
            else obj.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        DetectionBehaviour.OnObjectFound -= ObjectCollected;
        DetectionBehaviour.OnObjectWaiting -= WaitForCollection;
        DetectionBehaviour.OnObjectSaveLoaded -= ObjectSaveLoaded;
    }
}

using UnityEngine;

public class ObjectCollectedBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _darkness;

    private void Awake()
    {
        DetectionBehaviour.OnObjectFound += ObjectCollected;
        DetectionBehaviour.OnObjectWaiting += WaitForCollection;
    }

    private void WaitForCollection(DetectionBehaviour obj) // add feedbacks.
    {
        print("Wait for " + obj.name + "...");
        obj.transform.localScale *= 1.1f;
    }

    private void ObjectCollected(DetectionBehaviour obj) // add feedbacks.
    {
        print("You just collected " + obj.name + " !");

        if(obj.IsProgramm) _darkness.SetActive(false);
        else obj.gameObject.SetActive(false);
    }
}

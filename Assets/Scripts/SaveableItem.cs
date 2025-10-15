using UnityEngine;

public enum ItemType{
    PROGRAM,
    HIDDEN
}

public class SaveableItemBehaviour : MonoBehaviour
{
    [SerializeField] private ItemType _type;
    [SerializeField] private int _id;
    
    public bool IsFound => SaveManager.HasBeenFound(_type, _id);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (!IsFound)
        {
            DetectionBehaviour.OnObjectFound += OnObjectFound;
        }
    }

    void OnObjectFound(DetectionBehaviour behaviour)
    {
        if (behaviour.gameObject == gameObject)
        {
            SaveManager.SetAsFound(_type, _id);
            DetectionBehaviour.OnObjectFound -= OnObjectFound;
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using NUnit.Framework.Internal.Commands;

public class ManagerGalleryBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> _LockSprite;

    public static ManagerGalleryBehaviour Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        JustDoIt();
    }

    public void JustDoIt()
    {
        for (int i = 0; i < _LockSprite.Count; i++)
        {
            if (SaveManager.HasBeenFound(ItemType.PROGRAM, i))
            {
                _LockSprite[i].SetActive(false);
            }
        }
    }
}
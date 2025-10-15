using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ManagerGalleryBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> _LockSprite;

    private void Awake()
    {
        SaveManager.SetAsFound(ItemType.PROGRAM, 0);
        SaveManager.SetAsFound(ItemType.PROGRAM, 2);
        SaveManager.SetAsFound(ItemType.PROGRAM, 6);



        for (int i = 0; i < _LockSprite.Count; i++)
        {
            if (SaveManager.HasBeenFound(ItemType.PROGRAM, i))
            {
                _LockSprite[i].SetActive(false);
            }
        }
    }
}
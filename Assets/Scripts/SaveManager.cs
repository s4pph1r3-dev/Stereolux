using UnityEngine;

public static class SaveManager
{
    private const bool DOES_ERASE_ON_LOAD = true;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Awake()
    {
        if (DOES_ERASE_ON_LOAD)
        {
            PlayerPrefs.DeleteAll();
        }
    }
    
    public static bool HasBeenFound(ItemType type, int id)
    {
        return PlayerPrefs.GetInt($"{type}/{id}") == 1;
    }

    public static void SetAsFound(ItemType type, int id)
    {
        PlayerPrefs.SetInt($"{type}/{id}", 1);
    }
    
    public static void SetAsNotFound(ItemType type, int id)
    {
        PlayerPrefs.SetInt($"{type}/{id}", 0);
    }
}

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string saveFile => Path.Combine(Application.persistentDataPath, "game.json");

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        var state = new Dictionary<string, object>();
        foreach (var saveable in FindObjectsOfType<MonoBehaviour>(true))
        {
            if (saveable is ISaveable s)
            {
                state[saveable.gameObject.name] = s.CaptureState();
            }
        }

        File.WriteAllText(saveFile, JsonUtility.ToJson(new SerializationWrapper(state)));
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        if (!File.Exists(saveFile)) return;

        var json = File.ReadAllText(saveFile);
        var state = JsonUtility.FromJson<SerializationWrapper>(json).ToDictionary();

        foreach (var saveable in FindObjectsOfType<MonoBehaviour>(true))
        {
            if (saveable is ISaveable s && state.TryGetValue(saveable.gameObject.name, out object savedState))
            {
                s.RestoreState(savedState);
            }
        }

        Debug.Log("Game Loaded");
    }

    [System.Serializable]
    private class SerializationWrapper
    {
        public List<string> keys = new();
        public List<string> values = new();

        public SerializationWrapper(Dictionary<string, object> dict)
        {
            foreach (var kv in dict)
            {
                keys.Add(kv.Key);
                values.Add(JsonUtility.ToJson(kv.Value));
            }
        }

        public Dictionary<string, object> ToDictionary()
        {
            var dict = new Dictionary<string, object>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict[keys[i]] = JsonUtility.FromJson<object>(values[i]);
            }
            return dict;
        }
    }
}

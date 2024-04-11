using System;
using System.IO;
using System.Text;
using Unity.Serialization.Json;
using UnityEngine;

public class SaveStateSerializer
{
    /// <summary>  
    /// Serializes any object to a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of the object that you're serializing.</typeparam>
    /// <typeparam name="U">The type of the object that you're serializing.</typeparam>
    /// <param name="fileName">The relative path + name (without a file extension) of the file.</param>
    /// <param name="data">The data that you want to serialize.</param>
    public bool JSONToFile<U>(string fileName, U data)
    {
        JsonSerializationParameters parameters = new()
        {
            Minified = true
        };

        string json = JsonSerialization.ToJson(data, parameters);

        try
        {
            string path = $"{Application.persistentDataPath}/{fileName}.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            FileStream fs = File.Create(path);
            fs.Write(new UTF8Encoding(true).GetBytes(json));
            fs.Close();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Deserializes a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of the object that you're deserializing.</typeparam>
    /// <typeparam name="U">The type of the object that you're serializing.</typeparam>
    /// <param name="fileName">The relative path + name (without a file extension) to the file.</param>
    public U FileToJSON<U>(string fileName)
    {
        string path = $"{Application.persistentDataPath}/{fileName}.json";

        if (!File.Exists(path))
        {
            return default(U);
        }

        try {
            string potentialJSON = File.ReadAllText(path);
            U data = JsonSerialization.FromJson<U>(potentialJSON);

            return data;
        } catch (Exception e) {
            Debug.LogError(e.Message);
        }

        return default(U);
    }
}

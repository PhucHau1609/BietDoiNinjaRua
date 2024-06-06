// using System.Diagnostics;
// using System.IO;
// using UnityEditor.VersionControl;
// using UnityEngine;
// public class StorageManager
// {
//     //doc ghi file
//     public static bool SaveToFile(string filename, string json){
//         try{
//             var fileStream = new FileStream(filename, FileMode.Create);
//             using (var writer = new StreamWriter(fileStream)){
//                 writer.Write(json);
//             }
//             return true;
//         }catch(System.Exception e){
//             UnityEngine.Debug.LogError(message:"Error saving file: " + e.Message);
//             return false;
//         }
//     }
//     //load du lieu len
//     public static string LoadFromFile (string filename){
//         try{
//             if (File.Exists(filename)){
//                 var fileStream = new FileStream(filename, FileMode.Open);
//                 using (var reader = new StreamReader(fileStream)){
//                     return reader.ReadToEnd();
//                 }
//             } else {
//                 UnityEngine.Debug.LogError(message:"File not found: " + filename);
//                 return null;
//             }
//         }catch (System.Exception e){
//             UnityEngine.Debug.LogError(message:"Error loading file: " + e.Message);
//             return null;
//         }
//     }
// }
using UnityEngine;
using System.IO;

public static class StorageManager
{
    // Save data to a file
    public static bool SaveToFile(string filename, string json)
    {
        try
        {
            File.WriteAllText(filename, json);
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error saving file '{filename}': {e.Message}");
            return false;
        }
    }

    // Load data from a file
    public static string LoadFromFile(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                return File.ReadAllText(filename);
            }
            else
            {
                Debug.LogError($"File not found: {filename}");
                return null;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error loading file '{filename}': {e.Message}");
            return null;
        }
    }
}

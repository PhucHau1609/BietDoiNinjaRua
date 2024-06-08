using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using System.IO;
    using UnityEngine;
    public class StorageManager
    {
        public static bool SaveToFile(string filename, string json)
        {
            try
            {
                var fileStream = new FileStream(filename, FileMode.Create);
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(json);
                }
                return true;
            }
            catch (System.Exception e)
            {
                Debug.Log("Error saving: " + e.Message);
                return false;
            }
        }

        public static string LoadFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    var fileStream = new FileStream(filename, FileMode.Open);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    Debug.Log("file not found: " + filename);
                    return null;
                }
            }

            catch (System.Exception e )
            {
                Debug.Log("error load: " + e.Message);
                return null;
            }
           
        }
    }


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    /// <summary>
    /// Serializes (AKA Saves/Loads) data.
    /// </summary>
    public class Serialization
    {
        private JsonSerializer serializer;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Serialization()
        {
            serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializer.NullValueHandling = NullValueHandling.Include;

            
        }

        /// <summary>
        /// Adds a new converter to the json serializer.
        /// </summary>
        /// <param name="converter"></param>
        public void addConverter(JsonConverter converter)
        {
            serializer.Converters.Add(converter);
        }


        /// <summary>
        /// Deserializes an object from a .json file.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize.</typeparam>
        /// <param name="p">The path to the .json object.</param>
        /// <returns></returns>
        public T Deserialize<T>(string p)
        {
            string path = Path.Combine(Application.persistentDataPath, p);

            string json = "";
            foreach (var line in File.ReadAllLines(path))
            {
                json += line;
            }
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                var obj = serializer.Deserialize<T>(reader);
                return obj;
            }
        }

        /// <summary>
        /// Serializes an object to a .json file.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="o"></param>
        public void Serialize(string p, object o)
        {


            string path = Path.Combine(Application.persistentDataPath, p);

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //JsonUtility.ToJson(o);
                Debug.Log(path);
                serializer.Serialize(writer, o);
            }
        }
    }
}

using Assets.Scripts.Objects;
using Assets.Scripts.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager:MonoBehaviour
    {
        public List<Food> allFoodItems;
        public Serialization serializer;

        public void Start()
        {
            serializer = new Serialization();
            //serializer.Serialize("Player.json", getPlayer().GetComponent<CharacterController2D>().info);

            //serializer.Serialize("MinigameActionMash.json", new Minigames.MinigameActions.ButtonMashAction(100, Minigames.MinigameActions.ButtonMashAction.ButtonToMash.A));
        }

    
        /// <summary>
        /// Serialize a game object.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        public static void Serialize(string path, object obj)
        {
            getGameManager().serializer.Serialize(path, obj);
        }

        /// <summary>
        /// Deserialize aka load an object from a .json file.
        /// </summary>
        /// <typeparam name="T">The class type to deserialize.</typeparam>
        /// <param name="path">The relative path to the object</param>
        /// <returns></returns>
        public static T Deserialize<T>(string path)
        {
            return getGameManager().serializer.Deserialize<T>(path);
        }

        /// <summary>
        /// Serialize aka save a game object.
        /// </summary>
        /// <param name="path">The relative path to write to.</param>
        /// <param name="obj">The object to serialize.</param>
        public void serialize(string path, object obj)
        {
            serializer.Serialize(path, obj);
        }

        /// <summary>
        /// Deserialize, aka load an object from .json.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="path">The relative path to the .json file.</param>
        /// <returns></returns>
        public T deserialize<T>(string path)
        {
            return serializer.Deserialize<T>(path);
        }

        public Food getFood(string name)
        {
            foreach(Food nom in this.allFoodItems)
            {
                if (nom == null) continue;
                if (nom.name == name)
                {
                    Food obj= Instantiate(nom);
                    obj.transform.parent = getPlayer().transform;
                    obj.transform.localPosition = new Vector3(0.0f, 1.0f, 0);
                    return obj;
                }
            }
            return null;
        }

        public static GameObject getPlayer()
        {
            return GameObject.Find("Player");
        }

        public static GameManager getGameManager()
        {
            return GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        public static GameObject getObjectFromScene(string name)
        {
            return GameObject.Find(name);
        }

    }
}

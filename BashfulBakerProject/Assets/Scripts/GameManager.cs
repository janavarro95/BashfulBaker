using Assets.Scripts.Objects;
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
        
        public void Start()
        {
            
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

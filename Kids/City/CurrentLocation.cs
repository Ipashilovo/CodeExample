using System;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;

namespace City
{
    [CreateAssetMenu(fileName = "CurrentLocation", menuName = "ScriptableObjects/City/CurrentLocation", order = 1)]
    public class CurrentLocation : ScriptableObject
    {
        public void SetLocation(Locations locations)
        {
            string json = JsonConvert.SerializeObject(locations);
            PlayerPrefs.SetString("CurrentLocation", json);
        }

        public Locations GetLocation()
        {
            string json = PlayerPrefs.GetString("CurrentLocation");
            Locations locations = JsonConvert.DeserializeObject<Locations>(json);
            return locations;
        }
    }
}
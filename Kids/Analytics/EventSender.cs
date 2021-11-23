using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Analytics
{
    public class EventSender
    {
        public void SendLevelStart()
        {
            var metrica = AppMetrica.Instance;
            var activeScene = SceneManager.GetActiveScene();
            var parametrs = new Dictionary<string, object>
            {
                {"level_number", activeScene.buildIndex-1},
                {"level_name", activeScene.name},
                {"level_count",GlobalData.LevelCount},
                {"level_type","normal"},
            };
            metrica.ReportEvent("level_start",parametrs);
            metrica.SendEventsBuffer();
            GlobalData.IncreaseLevelCount();
        }

        public void SendLevelFinish(string levelType = "normal")
        {
            float time = Time.timeSinceLevelLoad;
            TimeOnLocation.Time = time;
            var metrica = AppMetrica.Instance;
            var activeScene = SceneManager.GetActiveScene();
            var parametrs = new Dictionary<string, object>
            {
                {"level_number", activeScene.buildIndex-1},
                {"level_name", activeScene.name},
                {"level_count",GlobalData.LevelCount},
                {"level_type",levelType},
                {"time", time},
            };
            metrica.ReportEvent("level_finish",parametrs);
            metrica.SendEventsBuffer();
        }
    }
}

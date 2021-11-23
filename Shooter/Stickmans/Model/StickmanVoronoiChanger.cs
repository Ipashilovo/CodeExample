using UnityEngine;

namespace DefaultNamespace.Stickman
{
    public class StickmanVoronoiChanger
    {
        public void Change(StickmanFacade stickmanFacade)
        {
            Vector3 position = stickmanFacade.transform.position;
            Quaternion rotation = stickmanFacade.transform.rotation;
            Object.Destroy(stickmanFacade.gameObject);
            var character = Resources.Load<FrozenCharacter>("FrozenCharacter");
            Object.Instantiate(character, position, rotation);
        }
    }
}
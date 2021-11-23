using GameSystems;

namespace UI.EndGame
{
    internal interface ILooseScreen
    {
        public void Init(LevelLoader levelLoader);
        public void Enable();
    }
}
using UnityEngine;


namespace Code.Infrastructure.StaticDatas
{
    [CreateAssetMenu(menuName = "Game", fileName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [Space(10)] [Header("Scenes")]
        public string InitialScene = "Initial";
        public string GameScene = "Game";
        public string MenuScene = "Menu";
    }   
}
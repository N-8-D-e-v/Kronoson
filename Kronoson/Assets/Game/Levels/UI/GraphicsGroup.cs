using UnityEngine;
using UnityEngine.UI;

namespace Game.Levels.UI
{
    public class GraphicsGroup : MonoBehaviour
    {
        //Public Fields
        public float Scale = 1f;
        
        //Assignables
        private Transform[] graphics;

        private void Awake()
        {
            Graphic[] _graphics = GetComponentsInChildren<Graphic>();
            graphics = new Transform[_graphics.Length];
            for (int _i = 0; _i < _graphics.Length; _i++)
                graphics[_i] = _graphics[_i].transform;
        }

        private void Update()
        {
            foreach (Transform _graphic in graphics) 
                _graphic.localScale = Vector3.one * Scale;
        }
    }
}
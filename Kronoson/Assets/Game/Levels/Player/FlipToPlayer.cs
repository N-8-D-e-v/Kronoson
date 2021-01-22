using UnityEngine;
using Game.General.Utilities.Transformf;

namespace Game.Levels.Player
{
    public class FlipToPlayer : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        
        //Tolerance
        [Range(0, 5)] [SerializeField] private float tolerance = 0.5f;
        
        //Scale
        private float scaleX = 1f;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            scaleX = transform.localScale.x;
        }

        private void Update()
        {
            float _playerPosX = PlayerData.GetPlayerPosition().x;
            float _posX = transform.position.x;
            float _dir = 0f;

            if (_posX < _playerPosX - tolerance)
                _dir = 1f;
            else if (_posX > _playerPosX + tolerance)
                _dir = -1f;
            transform.Flip(_dir, scaleX);
        }
    }
}
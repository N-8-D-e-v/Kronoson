using UnityEngine;

namespace Game.General.TimeManagement
{
    public class Timer
    {
        public float Time
        {
            set => time = Mathf.Max(0, value);
            get => time = Mathf.Max(time, 0);
        }

        private float time = 0f;

        public Timer(float _time) => time = _time;

            public void Tick(float _deltaTime) => time -= _deltaTime;
    }
}
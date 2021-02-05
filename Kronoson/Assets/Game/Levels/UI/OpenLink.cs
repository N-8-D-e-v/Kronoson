using UnityEngine;

namespace Game.Levels.UI
{
    public class OpenLink : MonoBehaviour
    {
        //Link
        [SerializeField] private string link = "https://www.youtube.com/N8Dev";


        public void Open() => Application.OpenURL(link);
    }
}
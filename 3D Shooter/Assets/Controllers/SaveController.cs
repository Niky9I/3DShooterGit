using System.IO;
using UnityEngine;

namespace Geekbrains
{
    public class SaveController
    {
        private IData<SerializableGameObject> _data;

        private string _folderName = "dataSave";
        private string _fileName = "data.txt";
        private string _path;

        public SaveController()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                //_data = new XMLData();
            }
            else
            {
                _data = new JsonData<SerializableGameObject>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
            
        }

        public void Save()
        {
            Debug.Log("сохраняю");
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var player = new SerializableGameObject
            {
                Pos = Main.Instance.Player.position,
                Name = "Player",
                IsEnable = true
            };

            _data.Save(player, Path.Combine(_path, _fileName));
        }

        public void Load()
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            Main.Instance.Player.position = newPlayer.Pos;
            Main.Instance.Player.name = newPlayer.Name;
            Main.Instance.Player.gameObject.SetActive(newPlayer.IsEnable);

            Debug.Log(newPlayer);
        }
    }
}
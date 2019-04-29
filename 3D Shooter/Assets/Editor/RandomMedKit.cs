using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Geekbrains.Editor
{
    public class RandomMedKit : EditorWindow
    {
        public GameObject _medKit;
        string _nameObject = "MedKit";
        int _countObject;
        bool groupEnabled;
        float _minDistance;
        int _radius;

        [MenuItem("Geekbrains/Расстановка аптечек")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(RandomMedKit));
        }
        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            _medKit = EditorGUILayout.ObjectField("Префаб аптечки", _medKit, typeof(GameObject), true) as GameObject;
            groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки" , groupEnabled);
            _countObject = EditorGUILayout.IntSlider("Количество объектов",_countObject, 1, 30);
            _radius = EditorGUILayout.IntSlider("Радиус разброса аптечек", _radius, 1, 100);
            EditorGUILayout.EndToggleGroup();
            if (GUILayout.Button("Создать объекты"))
            {
                if (_medKit)
                {
                    Transform root = new GameObject("Root").transform;
                    for (int i = 0; i < _countObject; i++)
                    {
                        Vector3 pos = new Vector3(Random.Range(-_radius, _radius),1, Random.Range(-_radius, _radius));
                        GameObject temp = Instantiate(_medKit, pos, Quaternion.identity) as GameObject;
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                    }
                }
            }
        }
    }
}

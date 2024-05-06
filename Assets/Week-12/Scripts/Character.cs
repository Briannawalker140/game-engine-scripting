using UnityEngine;
using static TreeEditor.TreeEditorHelper;

namespace CharacterEditor
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Head;
        [SerializeField] private MeshRenderer m_Body;
        [SerializeField] private MeshRenderer m_ArmR;
        [SerializeField] private MeshRenderer m_ArmL;
        [SerializeField] private MeshRenderer m_LegR;
        [SerializeField] private MeshRenderer m_LegL;
        private BodyTypes bodyType;

        private void Start()
        {
            Load();
        }

        public void Load()
        {
            //Load materials from the MaterialManager and pass in the id pulled from each PlayerPref here
            switch (bodyType)
            {
                case BodyTypes.Arm: PlayerPrefs.GetInt("Arm 0");
                    break;
                case BodyTypes.Leg: PlayerPrefs.GetInt("Leg 1");
                    break;
                case BodyTypes.Head: PlayerPrefs.GetInt("Head 2");
                    break;
                case BodyTypes.Body: PlayerPrefs.GetInt("Body 3");
                    break;
            }
        }
    }
}
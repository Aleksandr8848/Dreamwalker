using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using TMPro;

namespace Game.View
{
    public class Say : MonoBehaviour
    {
        [SerializeField] private Dialogs _dialogs;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _name;
        public GameObject DialogueWindow;

        private int _index;

       void Update()
        {
            if ( Input.GetKeyDown(KeyCode.T))
            {
                DialogueWindow.SetActive(!DialogueWindow.activeSelf);

                if (_dialogs != null && DialogueWindow.activeSelf)
                {
                    nextDialog();
                }
            }
        }

        public void nextDialog()
        {
            if (_index == _dialogs.Get.Length) return;

            _name.SetText(_dialogs.Get[_index].Name);
            _text.SetText(_dialogs.Get[_index].Text);
            _index++;
        }
    }
}

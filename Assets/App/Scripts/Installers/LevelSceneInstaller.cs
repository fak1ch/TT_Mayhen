using App.Scripts.General.PopUpSystemSpace;
using App.Scripts.Scenes.MainScene.Entities;
using UnityEngine;

namespace App.Scripts.Installers
{
    public class LevelSceneInstaller : Installer
    {
        private void Awake()
        {
            PopUpSystem.Instance.enabled = true;
        }
    }
}
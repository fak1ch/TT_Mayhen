using System;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    [Serializable]
    public class CharacterShelterConfig
    {
        public Ease Ease = Ease.Linear;
        public float StartTakeAimDuration = 0.5f;
        public float EndTakeAimDuration = 0f;
        public Transform TakeAimPoint;
    }
}
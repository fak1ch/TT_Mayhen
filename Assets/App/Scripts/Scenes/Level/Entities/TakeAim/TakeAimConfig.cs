﻿using System;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.TakeAim
{
    [Serializable]
    public class TakeAimConfig
    {
        public float AimSphereZ = 5;
        public float ChangeWeightDuration = 0.5f;
        public float TakeAimMoveDuration = 0.5f;
        public float TakeAimRotation = 0.5f;
        public Vector3 LocalMoveOffset;
        public Vector3 LocalEulerAnglesEnd;
    }
}
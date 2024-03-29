﻿using UnityEngine.UI;

namespace LeoDeg.Framework.UI
{
    public class UpdateButtonInteractability : UIPropertyUpdater
    {
        public Scriptables.BoolScriptable targetBool;
        public Button targetButton;

        public override void Raise()
        {
            targetButton.interactable = targetBool.value;
        }
    }
}

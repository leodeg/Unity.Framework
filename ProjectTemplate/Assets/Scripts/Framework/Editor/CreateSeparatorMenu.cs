﻿using UnityEngine;
using UnityEditor;

namespace LeoDeg.Framework.Editor
{
    public class CreateSeparatorMenu : MonoBehaviour
    {
        [MenuItem ("LeoDeg/Hierarchy Separator %#&s")]
        public static void CreateHierarchySeparator ()
        {
            GameObject separator = new GameObject ();
            separator.name = "-----------------";
        }
    }
}
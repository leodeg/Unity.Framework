using UnityEngine;
using UnityEditor;
using System.Collections;

namespace LeoDeg.Editor
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
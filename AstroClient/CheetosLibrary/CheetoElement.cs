namespace CheetosLibrary
{
    using UnityEngine;

    // TODO: Finish
    public class CheetoElement
    {
        public GameObject Self;
        public GameObject Parent;

        public CheetoElement()
        {
        }

        public void SetName(string name)
        {
            Self.name = name;
        }

        public void ApplyFixes()
        {
            Self.transform.parent = Parent.transform;
            Self.transform.rotation = Parent.transform.rotation;
            Self.transform.localPosition = new Vector3(0, 0, 0);
            Self.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
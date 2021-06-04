﻿namespace AstroClient.variables
{
	using System.Collections.Generic;
	using UnityEngine;

	public class GlobalLists : GameEvents
    {
        public static List<GameObject> ClonedObjects = new List<GameObject>();
        public static List<Renderer> RenderObjects = new List<Renderer>();

        public override void OnLevelLoaded()
        {
            ClonedObjects.Clear();
            RenderObjects.Clear();
        }
    }
}
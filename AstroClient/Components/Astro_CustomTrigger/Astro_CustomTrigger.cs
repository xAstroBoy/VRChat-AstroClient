using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.ProgramSources;

namespace AstroClient.Components
{
	public class Astro_CustomTrigger : MonoBehaviour
	{

		private UdonBehaviour beh;
		private IUdonHeap heap;

		public Astro_CustomTrigger(IntPtr ptr)
			: base(ptr)
		{
		}


		public void Start()
		{
			var OldInteractable = gameObject.GetComponent<VRCInteractable>();
			if(OldInteractable != null)
			{
				UnityEngine.Object.Destroy(OldInteractable);
			}
			beh = base.gameObject.AddComponent<UdonBehaviour>();
			beh.serializedProgramAsset = Custom_Trigger_Initializator.Custom_Trigger_ProgramAsset;
			beh.InitializeUdonContent();
			beh.Start();
			beh.interactText = InteractText;
		}

		public void FixedUpdate()
		{
			if (beh != null && beh._udonVM != null && !beh._udonManager != null)
			{
				if (heap == null)
				{
					heap = beh._udonVM.InspectHeap();
				}
				if (heap != null && heap.GetHeapVariable(2u).Unbox<bool>())
				{
					OnInteract();
					heap.CopyHeapVariable(3u, 2u);
				}
			}
		}



		internal string InteractText { get; set; } = "Use";

		internal Action OnInteract  { get; set; }


	}
}

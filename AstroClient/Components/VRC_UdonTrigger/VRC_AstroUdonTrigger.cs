using AstroLibrary.Console;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.ProgramSources;

namespace AstroClient.Components
{
	public class VRC_UdonTrigger : MonoBehaviour
	{

		public VRC_UdonTrigger(IntPtr ptr)
			: base(ptr)
		{
		}




		public void Start()
		{
			if (gameObject.GetComponent<VRCInteractable>() != null)
			{
				UnityEngine.Object.Destroy(gameObject.GetComponent<VRCInteractable>());
			}


			if (UdonTrigger_Helper.OnInteractUdonProgramEvent == null)
			{
				ModConsole.DebugError("Custom Trigger Can't Load as Program Asset is null!");
			}
			Behaviour = gameObject.AddComponent<UdonBehaviour>();
			if (Behaviour != null)
			{
				Behaviour.serializedProgramAsset = UdonTrigger_Helper.OnInteractUdonProgramEvent;
				Behaviour.InitializeUdonContent();
				Behaviour.Start();
				Behaviour.interactText = InteractText;
			}
		}

		public void FixedUpdate()
		{
			if (Behaviour == null)
			{
				Behaviour = base.gameObject.AddComponent<UdonBehaviour>();
				Behaviour.serializedProgramAsset = UdonTrigger_Helper.OnInteractUdonProgramEvent;
				Behaviour.InitializeUdonContent();
				Behaviour.Start();
				Behaviour.interactText = InteractText;
			}
			else
			{
				if(Behaviour.serializedProgramAsset == null)
				{
					Behaviour.serializedProgramAsset = UdonTrigger_Helper.OnInteractUdonProgramEvent;
					Behaviour.InitializeUdonContent();
					Behaviour.Start();
				}

				if (Behaviour != null && Behaviour._udonVM != null && !Behaviour._udonManager != null)
				{
					if (UdonHeap == null)
					{
						UdonHeap = Behaviour._udonVM.InspectHeap();
					}
					if (UdonHeap != null && UdonHeap.GetHeapVariable(2u).Unbox<bool>())
					{
						OnInteract();
						UdonHeap.CopyHeapVariable(3u, 2u);
					}
				}
			}
		}


		private string _InteractText  = "Use";
		
		internal string InteractText
		{
			get
			{
				return _InteractText;
			}
			set
			{
				_InteractText = value;
				if (Behaviour != null)
				{
					if (Behaviour.interactText != value)
					{
						Behaviour.interactText = value;
					}
				}
			}
		}

		internal Action OnInteract { get; set; }

		private UdonBehaviour Behaviour;
		private IUdonHeap UdonHeap;

	}
}

using AstroClient.ItemTweaker;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;

#region AstroClient Imports

using static AstroClient.ObjectMiscOptions;

#endregion AstroClient Imports

namespace AstroClient.components
{
	public class ItemInflater : GameEventsBehaviour
	{
		public Delegate ReferencedDelegate;
		public IntPtr MethodInfo;
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public ItemInflater(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		public ItemInflater(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ItemInflater>())
		{
			ClassInjector.DerivedConstructorBody(this);

			ReferencedDelegate = referencedDelegate;
			MethodInfo = methodInfo;
		}

		~ItemInflater()
		{
			Marshal.FreeHGlobal(MethodInfo);
			MethodInfo = IntPtr.Zero;
			ReferencedDelegate = null;
			AntiGcList.Remove(this);
			AntiGcList = null;
		}

		// Use this for initialization
		private void Start()
		{
			var RigidBody = GetComponentInChildren<Rigidbody>(true);
			obj = RigidBody.gameObject;
			NewSize = obj.transform.localScale;
			ItemInflaterManager.Register(this);
			OnlineEditor.TakeObjectOwnership(obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SelfDestroy()
		{
			try
			{
				OnlineEditor.RemoveOwnerShip(obj);
				ItemInflaterManager.RemoveObject(obj);
				DestroyImmediate(this);
			}
			catch (Exception)
			{
			}
		}

		// Update is called once per frame
		private void Update()
		{
			try
			{
				if (obj != null)
				{
					if ((Time.time - LastTimeCheck > InflateTimer))
					{
						if (obj.transform.localScale != NewSize)
						{
							// X
							FixX();
							// Y
							FixY();
							// Z
							FixZ();
							// Update Button
							if (Tweaker_Object.CurrentSelectedObject == obj)
							{
								GameObjectActualScale.setButtonText("Object 's Current scale : " + obj.transform.localScale.ToString());
							}
						}
						LastTimeCheck = Time.time;
					}
				}
			}
			catch (Exception)
			{
				DestroyImmediate(obj.GetComponent<ItemInflater>());
			}
		}

		private void FixX()
		{
			if (obj.transform.localScale.x <= NewSize.x)
			{
				obj.transform.localScale = new Vector3(obj.transform.localScale.x + 0.1f, obj.transform.localScale.y, obj.transform.localScale.z);
			}
			if (obj.transform.localScale.x >= NewSize.x)
			{
				obj.transform.localScale = new Vector3(obj.transform.localScale.x - 0.1f, obj.transform.localScale.y, obj.transform.localScale.z);
			}
		}

		private void FixY()
		{
			if (obj.transform.localScale.y <= NewSize.y)
			{
				obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y + 0.1f, obj.transform.localScale.z);
			}
			if (obj.transform.localScale.y >= NewSize.y)
			{
				obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y - 0.1f, obj.transform.localScale.z);
			}
		}

		private void FixZ()
		{
			if (obj.transform.localScale.z <= NewSize.z)
			{
				obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, obj.transform.localScale.z + 0.1f);
			}
			if (obj.transform.localScale.z >= NewSize.z)
			{
				obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, obj.transform.localScale.z - 0.1f);
			}
		}

		public float TimerOffset = 0f;
		private float LastTimeCheck = 0;
		private float InflateTimer = 0.05f;
		public ItemInflaterManager Manager = null;
		private GameObject obj = null;
		internal Vector3 NewSize;
	}
}
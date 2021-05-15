namespace AstroClient.AvatarMods
{
	using AstroClient.Extensions;
	using Photon.Realtime;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using VRC.SDKBase;

	class AvatarModifier : GameEvents
	{

		public static void InitButtons(QMTabMenu tab , float x, float y, bool btnHalf)
		{
			var tmp = new QMNestedButton(tab, x, y, "Avatar Modifiers", "Modify Other's avatars", null, null, null, null, btnHalf);
			new QMSingleButton(tmp, 5, 0, "Reload All Avatars", () => { AvatarUtils.Reload_All_Avatars(); }, "Reloads All avatars", null, null, true);
			RemoveMasksToggle = new QMSingleToggleButton(tmp, 1, 0, "Remove Masks", () => { MaskDeleter = true; }, "Remove Masks", () => { MaskDeleter = false; }, "Remove Masks From all avatars (Requires Avatar Reload)", Color.green, Color.red, null, false, true);
			LewdifyToggle = new QMSingleToggleButton(tmp, 1, 0.5f, "Lewdify", () => { Lewdify = true; }, "Lewdify", () => { Lewdify = false; }, "Lewdify avatars (Requires a Avatar Reload)", Color.green, Color.red, null, false, true);

		}



		public override void OnAvatarSpawn(GameObject avatar, VRC_AvatarDescriptor DescriptorObj, bool state)
		{
			if (avatar != null && DescriptorObj != null)
			{
				var player = avatar.transform.root.GetComponentInChildren<Player>();
				if (player != null)
				{
					var manager = player.field_Public_Player_0._vrcplayer.prop_VRCAvatarManager_0;
					if (manager != null)
					{
						if (manager.prop_VRCAvatarDescriptor_0 != null && manager.prop_VRC_AvatarDescriptor_0 != null)
						{
							var apiavatar = manager.field_Private_ApiAvatar_1;
							if (apiavatar != null)
							{

								if (!string.IsNullOrEmpty(apiavatar.assetUrl) && !string.IsNullOrEmpty(apiavatar.id))
								{
									var root = avatar.transform.root;
									if (root != null)
									{
										// APPLY EDITS HERE, AS THIS WORKS BUT FILTER ALWAYS ARMATURE Childs out.


										var AvatarHolder = root.Get_Avatar();
										var Armature = root.Get_Armature();
										var Body = root.Get_Body();

										if (AvatarHolder != null && Armature != null && Body != null)
										{

											var childs = AvatarUtils.AvatarParents(AvatarHolder, Armature, Body);
											if (childs.Count() != 0 && childs != null)
											{
												if (MaskDeleter)
												{
													RemoveMasks(childs);
												}
												if(Lewdify)
												{
													
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		
		public static void RemoveClothes(List<Transform> items)
		{

		}

		public static void EnableNSFW(List<Transform> items)
		{

		}


		// Destroys Masks.
		public static void RemoveMasks(List<Transform> items)
		{
			foreach(var item in items)
			{
				if(item != null)
				{
					if (item.name.ToLower() == "mask")
					{
						item.gameObject.DestroyMeLocal();
					}
					else
					{
						foreach (var child in item.GetComponentsInChildren<Transform>(true))
						{
							if (child != null)
							{
								if (child.name.ToLower() == "mask")
								{
									child.gameObject.DestroyMeLocal();
								}
							}
						}
					}
				}
			}

		}




		public static QMSingleToggleButton LewdifyToggle { get; set; }

		private static bool _Lewdify = false;
		public static bool Lewdify
		{
			get
			{
				return _Lewdify;
			}
			set
			{
				_Lewdify = value;
				if (Lewdify != null)
				{
					LewdifyToggle.setToggleState(value);
				}
			}
		}





		public static QMSingleToggleButton RemoveMasksToggle { get; set; }

		private static bool _MaskDeleter = false;
		public static bool MaskDeleter
		{
			get
			{
				return _MaskDeleter;
			}
			set
			{
				_MaskDeleter = value;
				if(RemoveMasksToggle != null)
				{
					RemoveMasksToggle.setToggleState(value);
				}
			}
		}
	}
}

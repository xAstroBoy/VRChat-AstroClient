namespace AstroClient.AntiCrash
{
	internal class AntiCrashPolys
	{/*
        public static Dictionary<string, avatar_data> anti_crash_list = new Dictionary<string, avatar_data>();
        public static string[] shader_list;
        public static List<string> shader_list_local = new List<string>();
		public static int max_polygons = 500000;
		public static int max_particles = 30000;
		public static int max_particle_sys = 20;
		public static int max_meshes = 10;
		public static string[] shader_list1;
		public static List<string> shader_list_local1 = new List<string>();
		public static int get_meshes(Player p)
		{
			if (p.prop_VRCPlayer_0.prop_VRCAvatarManager_0 == null || p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0 == null)
			{
				return 0;
			}
			return p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0.field_Public_Int32_2;
		}
		public static int get_poly(Player p)
		{
			if (p.prop_VRCPlayer_0.prop_VRCAvatarManager_0 == null || p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0 == null)
			{
				return 0;
			}
			return p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0.field_Public_Int32_0;
		}
		public static int get_particle_systems(Player p)
		{
			if (p.prop_VRCPlayer_0.prop_VRCAvatarManager_0 == null || p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0 == null)
			{
				return 0;
			}
			return p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0.field_Public_Int32_7;
		}
		public static bool is_known(string shader)
		{
			return (shader_list.Contains(shader)) || shader_list_local.Contains(shader);
		}
		public static string[] to_array(WebResponse res)
		{
			return convert(res).Split(Environment.NewLine.ToCharArray());
		}
		public static string convert(WebResponse res)
		{
			string result = "";
			using (Stream responseStream = res.GetResponseStream())
			{
				using (StreamReader streamReader = new StreamReader(responseStream))
				{
					result = streamReader.ReadToEnd();
				}
			}
			res.Dispose();
			return result;
		}
		public static string[] get_shader_blacklist()
		{
			WebRequest webRequest = WebRequest.Create("https://raw.githubusercontent.com/morag12/vrchat_useful_mod/master/blacklist-shaders.txt");
			HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.BypassCache);
			webRequest.CachePolicy = cachePolicy;
			ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate c, X509Chain cc, SslPolicyErrors ssl) => true);
			return (from x in to_array(webRequest.GetResponse())
					where !string.IsNullOrEmpty(x)
					select x).ToArray<string>();
		}
		public static int get_mat_slots(Player p)
		{
			if (p.prop_VRCPlayer_0.prop_VRCAvatarManager_0 == null || p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0 == null)
			{
				return 0;
			}
			return p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0.field_Public_Int32_3;
		}

		public static int get_skinned_meshes(Player p)
		{
			if (p.prop_VRCPlayer_0.prop_VRCAvatarManager_0 == null || p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0 == null)
			{
				return 0;
			}
			return p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0.field_Public_Int32_1;
		}
		public static int get_particles_max(Player p)
		{
			if (p.prop_VRCPlayer_0.prop_VRCAvatarManager_0 == null || p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0 == null)
			{
				return 0;
			}
			return p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0.field_Public_Int32_8;
		}

		public static int get_particle_mesh_polys(Player p)
		{
			if (p.prop_VRCPlayer_0.prop_VRCAvatarManager_0 == null || p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0 == null)
			{
				return 0;
			}
			return p.prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_AvatarPerformanceStats_0.field_Public_Int32_9;
		}
		public struct avatar_data
		{
			public string asseturl;
			public int polys;
		}
		public static void set_pickups(bool state)
		{
			foreach (VRC_Pickup vrc_Pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>())
			{
				if (!(vrc_Pickup == null) && !vrc_Pickup.name.Contains("ViewFinder"))
				{
					vrc_Pickup.gameObject.SetActive(state);
				}
			}
		}
		public static bool particle_check(Player user)
		{
			Il2CppArrayBase<ParticleSystem> componentsInChildren = user.GetComponentsInChildren<ParticleSystem>(true);
			if (componentsInChildren == null || componentsInChildren.Count == 0)
			{
				return false;
			}
			int num = get_particles_max(user);
			int num2 = get_particle_mesh_polys(user);
			int num3 = get_particle_systems(user);
			if (num >= max_particles || num2 >= max_particles || num3 >= max_particle_sys)
			{
				for (int i = 0; i < componentsInChildren.Count; i++)
				{
					ParticleSystem particleSystem = componentsInChildren[i];
					if (!(particleSystem == null))
					{
						ParticleSystemRenderer component = particleSystem.GetComponent<ParticleSystemRenderer>();
						if (!(component == null) && component.enabled)
						{
							particleSystem.Stop(true);
							component.enabled = false;
							UnityEngine.Object.Destroy(particleSystem);
							UnityEngine.Object.Destroy(component);
						}
					}
				}
				return true;
			}
			return false;
		}
		public static bool polygon_check(Player user, int polys)
		{
			if (polys >= max_polygons)
			{
				Il2CppArrayBase<Renderer> componentsInChildren = user.prop_VRCPlayer_0.prop_VRCAvatarManager_0.GetComponentsInChildren<Renderer>(true);
				for (int i = 0; i < componentsInChildren.Count; i++)
				{
					Renderer renderer = componentsInChildren[i];
					if (!(renderer == null) && renderer.enabled)
					{
						renderer.enabled = false;
						UnityEngine.Object.Destroy(renderer);
					}
				}
				return true;
			}
			return false;
		}
		public static bool shader_check(Player user)
		{
			Il2CppArrayBase<Renderer> componentsInChildren = user.prop_VRCPlayer_0.prop_VRCAvatarManager_0.GetComponentsInChildren<Renderer>(true);
			Shader shader = Shader.Find("Standard");
			bool result = false;
			for (int i = 0; i < componentsInChildren.Count; i++)
			{
				Renderer renderer = componentsInChildren[i];
				if (!(renderer == null))
				{
					for (int j = 0; j < renderer.materials.Count; j++)
					{
						Material material = renderer.materials[j];
						if (is_known(material.shader.name))
						{
							material.shader = shader;
							result = true;
						}
					}
				}
			}
			return result;
		}
		public static bool mesh_check(Player user)
		{
			Il2CppArrayBase<MeshFilter> componentsInChildren = user.GetComponentsInChildren<MeshFilter>(true);
			if (get_meshes(user) >= max_meshes || get_skinned_meshes(user) >= max_meshes || get_mat_slots(user) >= max_meshes)
			{
				foreach (MeshFilter meshFilter in componentsInChildren)
				{
					UnityEngine.Object.Destroy(meshFilter);
				}
				return true;
			}
			return false;
		}
		public static bool mats_check(Player user)
		{
			Il2CppArrayBase<Material> componentsInChildren = user.GetComponentsInChildren<Material>(true);
			if (get_mat_slots(user) >= max_meshes)
			{
				foreach (Material material in componentsInChildren)
				{
					UnityEngine.Object.Destroy(material);
				}
				return true;
			}
			return false;
		}
		public static bool work_hk(Player user, int polys)
		{
			bool result;
			try
			{
				if (shader_list.Length == 0)
				{
					shader_list = get_shader_blacklist();
				}
				if (user == null)
				{
					result = false;
				}
				else
				{
					bool flag = particle_check(user);
					bool flag2 = polygon_check(user, polys);
					bool flag3 = mesh_check(user);
					bool flag4 = mats_check(user);
					bool flag5 = false;
					flag5 = shader_check(user);
					if (flag5)
					{
						MelonModLogger.Log("[!!!] nuked shaders for \"" + user.field_Private_APIUser_0.displayName.ToString() + "\"");
					}
					if (flag)
					{
						MelonModLogger.Log("[!!!] nuked particles for \"" + user.field_Private_APIUser_0.displayName.ToString() + "\"");
					}
					if (flag2)
					{
						MelonModLogger.Log("[!!!] nuked avatar for \"" + user.field_Private_APIUser_0.displayName.ToString() + "\"");
					}
					if (flag3)
					{
						MelonModLogger.Log("[!!!] nuked meshes for \"" + user.field_Private_APIUser_0.displayName.ToString() + "\"");
					}
					if (flag3)
					{
						MelonModLogger.Log("[!!!] nuked materials for \"" + user.field_Private_APIUser_0.displayName.ToString() + "\"");
					}
					if (flag2 || flag3 || flag || flag5 || flag4)
					{
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

	*/}
}
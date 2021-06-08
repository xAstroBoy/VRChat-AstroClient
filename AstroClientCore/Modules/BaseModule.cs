namespace AstroClientCore.Modules
{
	public partial class BaseModule
	{
		public string Name { get; private set; }

		public byte[] ImageData { get; private set; }

		public BaseModule(string name, byte[] imageData)
		{
			Name = name;
			ImageData = imageData;
		}

		public virtual void Start()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void LateUpdate()
		{
		}

		public virtual void VRChat_OnUiManagerInit()
		{
		}

		public virtual void OnApplicationQuit()
		{
		}

		public virtual void OnGUI()
		{
		}
	}
}

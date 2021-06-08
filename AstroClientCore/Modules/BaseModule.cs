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
	}
}

namespace MonoDumper
{
	using MelonLoader;
	using System;
	using System.IO;
	using System.Reflection;
	using System.Text;

	public class Main : MelonMod
	{
		public override void OnApplicationStart()
		{
			var dumpFolderPath = Environment.CurrentDirectory + @"\AstroClient\MonoDumps";
			var dumpFilePath = dumpFolderPath + @"\MonoDump.txt";

			if (!Directory.Exists(dumpFolderPath))
			{
				Directory.CreateDirectory(dumpFolderPath);
			}

			if (!File.Exists(dumpFilePath))
			{
				FileStream fs = new FileStream(dumpFilePath, FileMode.Create);
				fs.Dispose();
			}

			StringBuilder stringBuilder = new StringBuilder();

			foreach (Type type in Assembly.LoadFile(Environment.CurrentDirectory + @"\MelonLoader\Managed\Assembly-CSharp.dll").GetTypes())
			{
				stringBuilder.Append("\n\n*********************************************************************");
				stringBuilder.Append("Class: " + type.Name + Environment.NewLine);
				try
				{
					MemberInfo[] array = type.GetMethods();
					foreach (MemberInfo memberInfo in array)
					{
						stringBuilder.Append("Method: " + memberInfo.Name + Environment.NewLine);
					}
					foreach (PropertyInfo propertyInfo in type.GetProperties())
					{
						stringBuilder.Append("Propertie: " + propertyInfo.Name + Environment.NewLine);
					}
				}
				catch (Exception e)
				{
					stringBuilder.Append($"Failed: {e.Message}\n\n");
				}
				stringBuilder.Append("*********************************************************************\n\n");
			}
			File.AppendAllText(dumpFilePath, stringBuilder.ToString());
			Console.WriteLine("All dumped!");
			Console.ReadLine();
		}
	}
}

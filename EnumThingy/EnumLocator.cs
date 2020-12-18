using EnumThingy.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumThingy
{

	public class EnumLocator
	{
		private string _assemblyName = "ExternalDllWithEnums";
		private Assembly _assembly;

		public EnumLocator()
		{
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
				+ $"\\{_assemblyName}.dll";

			_assembly = Assembly.LoadFile(path);
		}


		public int GetEnumValue(string enumName, string enumValueName)
		{
			Type type = _assembly.GetType($"{_assemblyName}.Enums.{enumName}");
			if (type?.IsEnum == true)
			{
				var result = Enum.Parse(type, enumValueName);
				return (int)result;
			}

			throw new EnumNotFoundException($"Enum '{enumName}' not found");
		}

	}
}

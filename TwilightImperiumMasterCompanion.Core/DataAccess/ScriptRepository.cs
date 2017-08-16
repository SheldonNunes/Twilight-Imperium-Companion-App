using System.IO;
using System.Reflection;
using TwilightImperiumMasterCompanion.Core.DataAccess.Interfaces;

namespace TwilightImperiumMasterCompanion.Core.DataAccess
{
    public class ScriptRepository : IScriptRepository
    {
        public string GetScript(string scriptName)
        {
			var assembly = typeof(ScriptRepository).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("TwilightImperiumMasterCompanion.Core.DataAccess.Scripts." + scriptName);

			string text = "";
			using (var reader = new StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}

            return text;
        }
    }
}

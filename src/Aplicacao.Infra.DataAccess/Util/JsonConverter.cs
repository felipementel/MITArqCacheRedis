using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Aplicacao.Infra.DataAccess.Util
{
    public static class ConverterSimpleJson<T> where T : class, new()
    {
        public static T CriarJson(string json)
        {
            return (T)JsonSerializer.Deserialize<T>(json,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
        }
    }
}

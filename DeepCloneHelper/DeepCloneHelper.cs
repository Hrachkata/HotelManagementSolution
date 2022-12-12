using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeepCloneHelper;

public static class DeepCloneHelper
{
    public static T CreateDeepCopy<T>(T obj)
    {
        using (var ms = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(ms);
        }
    }
}
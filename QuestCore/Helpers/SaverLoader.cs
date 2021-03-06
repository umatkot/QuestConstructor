﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuestCore
{
    /// <summary>
    /// Сохранение и чтение объектов в/из файла
    /// </summary>
    public class SaverLoader
    {
        /// <summary>
        /// Сохранение объекта в файл
        /// </summary>
        public static void Save<T>(T obj, string filePath)
        {
            using (var fs = File.OpenWrite(filePath))
                new BinaryFormatter().Serialize(fs, obj);
        }

        /// <summary>
        /// Чтение объекта из файла
        /// </summary>
        public static T Load<T>(string filePath)
        {
            using (var fs = File.OpenRead(filePath))
                return (T)new BinaryFormatter().Deserialize(fs);
        }
    }
}

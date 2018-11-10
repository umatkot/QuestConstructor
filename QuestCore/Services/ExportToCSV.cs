using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuestCoreNS
{
    /// <summary>
    /// Экспорт анкет в CSV
    /// </summary>
    public class ExportToCSV
    {
        public string Separator { get; set; } = ";";
        public Encoding Encoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// Экспорт заполненых анкет в CSV
        /// </summary>
        public void Export(IEnumerable<Anketa> anketas, string fileName)
        {
            //получаем имена всех вопросов
            var questNames = anketas.SelectMany(a => a).Select(a => a.QuestId).Distinct().ToArray();
            //открываем файл на запись
            using (var sw = new StreamWriter(fileName, false, Encoding))
            {
                //пишем шапку CSV
                sw.WriteLine(string.Join(Separator, questNames));
                //перебираем анкеты
                foreach (var anketa in anketas)
                {
                    var nameToAnswer = new Dictionary<string, string>();
                    //перебираем ответы
                    foreach (var answer in anketa)
                        nameToAnswer[answer.QuestId] = answer.ToString();

                    //пишем ответы
                    for (int i = 0; i < questNames.Length; i++)
                    {
                        if (i > 0) sw.Write(Separator);
                        if (nameToAnswer.ContainsKey(questNames[i]))
                            sw.Write(nameToAnswer[questNames[i]]);
                    }

                    sw.WriteLine();
                }
            }
        }
    }
}

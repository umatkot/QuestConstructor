using System.Data.OleDb;
using System.Linq;

namespace QuestCoreNS
{
    /// <summary>
    /// Экспорт в базу данных
    /// </summary>
    public class ExportToDB
    {
        public string ConnectionString { get; set; } = @"Provider=Microsoft.ACE.OleDb.12.0; data source=C:\export.xlsx;Extended Properties=Excel 12.0";
        public string TableName { get; set; } = "Лист1$";
        public bool ExportAltTextInsteadOfCode { get; set; } = false;

        public void Export(Questionnaire questionnaire, Anketa anketa)
        {
            using (var conn = new OleDbConnection(ConnectionString))
            {
                //формируем список колонок
                var columnsList = string.Join(", ", questionnaire.Select(q => q.Id));

                //формируем список параметров
                var paramsList = string.Join(", ", questionnaire.Select(q => "@" + q.Id));
                var sql = string.Format("INSERT INTO [{2}]({0}) VALUES({1});", columnsList, paramsList, TableName);

                //создаем команду
                using (var command = new OleDbCommand(sql, conn))
                {
                    //инициализируем параметры значениями
                    foreach (var q in questionnaire)
                    {
                        var answer = anketa.FirstOrDefault(a => a.QuestId == q.Id);
                        var val = GetExportedAlternativeValue(q, answer);
                        command.Parameters.AddWithValue("@" + q.Id, val);
                    }

                    //исполняем SQL запрос
                    conn.Open();
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        private object GetExportedAlternativeValue(Quest quest, Answer answer)
        {
            if (answer == null) return null;

            if (ExportAltTextInsteadOfCode)
            {
                if (answer.Text != null)
                    return answer.Text;
                var alt = quest.FirstOrDefault(a => a.Code == answer.AlternativeCode);
                return alt?.Title;
            }
            else
            {
                return answer.ToString();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace DataLib
{
    public class DataClass
    {
        public static void MultiString(ref string baseStr, string appendStr)
		{
            baseStr =  baseStr + "\n" + appendStr;
		}

        /*
        /// <summary>
        /// Выводит информацию о табдицы в Trace
        /// Старая версия
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int DTtoTrace(DataTable dataTable)
        {
            try
            {
                Trace.WriteLine("");
                Trace.WriteLine("Общая информация");
                Trace.WriteLine(String.Format("Columns count = " + dataTable.Columns.Count));
                Trace.WriteLine(String.Format("Rows count = " + dataTable.Rows.Count));

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Trace.Write("|");
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        Trace.Write(String.Format("{0,3}", dataTable.Rows[i].ItemArray[j].ToString()));
                        Trace.Write("|");
                    }
                    Trace.WriteLine("");
                }

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    Trace.WriteLine(String.Format(dataTable.Columns[i].ColumnName + " " + dataTable.Columns[i].DataType));
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }
        */

        /// <summary>
        /// Выводит информацию о табдицы в Trace
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static int DTtoTrace(DataTable dataTable)
        {
            try
            {
                Trace.WriteLine(DTInfo(dataTable));
                Trace.WriteLine(DTData(dataTable));
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Выводит информацию о таблице в виде строки
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static string DTInfo(DataTable dataTable)
		{
            try
			{
                string outString = "";
                MultiString(ref outString, "Общая информация");
                MultiString(ref outString, String.Format("Columns count = " + dataTable.Columns.Count));
                MultiString(ref outString, String.Format("Rows count = " + dataTable.Rows.Count));

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    MultiString(ref outString, String.Format(dataTable.Columns[i].ColumnName + " " + dataTable.Columns[i].DataType));
                }
                return outString;
			}
            catch(Exception ex)
			{
                return ex.Message;
			}
		}

        /// <summary>
        /// Выводит содежание таблицы в виде строки
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static string DTData(DataTable dataTable)
        {
            try
            {
                string outString = "";
                MultiString(ref outString, "Таблица с данными");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string str = "|";
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        str = str + String.Format("{0,3}", dataTable.Rows[i].ItemArray[j].ToString());
                        str = str + "|";
                    }
                    MultiString(ref outString, str);
                }
                return outString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //TODO Избавься от следующих двух методов заменив их чем то адекватным
        //public static object[] MyGetArray( DataGrid dataGrid)
        //{
        //    try
        //    {
        //        DataRowView row = dataGrid.SelectedItem as DataRowView;
        //        return row.Row.ItemArray;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //}

        //public static string MyGetItemArray(DataGrid dataGrid, int i)
        //{
        //    try
        //    {
        //        object[] array = MyGetArray(dataGrid);
        //        return array[i].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //}

        /// <summary>Используется для формирования строки-перечисления пар ([название столбца] = [значение]). Идеально подходит для Insert запроса в SQL </summary>
        public static string ArrayToValue(string[] valueName, string[] value)
        {
            List<string> valueСollection = new List<string>();
            for (int i = 0; i < valueName.Length; i++)
                valueСollection.Add(String.Concat(valueName[i], "=", value[i]));
            string resultStr = String.Join(", ", valueСollection);
            Trace.WriteLine(resultStr);
            return resultStr;
        }

        /// <summary>
        /// Возвращает Brash цвет которого совпадает со входной строкой
        /// </summary>
        /// <param name="colorString">Не забудь использовать #</param>
        /// <returns></returns>
        public static Brush ColorStringConverter(string colorString)
		{
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(colorString);
            return brush;
        }
    }
}

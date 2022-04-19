using ForecastApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForecastApp.Models
{
    public class IndicatorsCompany_Model
    {
        Entities.ForecastEntities context = new Entities.ForecastEntities();

        /// <summary>
        /// Получение списка всех id
        /// </summary>
        /// <returns>список id</returns>
        public List<int> GetAllId()
        {
            var output = new List<int>();

            var query = from c in context.Forecast
                        select c.id;

            foreach (var i in query)
                output.Add(i);

            return output;
        }

        /// <summary>
        /// Получить список всех полных наименований товара
        /// </summary>
        /// <param name="AllIdForecast">список всех id</param>
        /// <returns>список товаров</returns>
        public List<string> GetAllItem(List<int> AllIdForecast)
        {
            var list = new List<string>();

            foreach (var i in AllIdForecast)
                list.Add(GetOneItem(i));
            var output = list.Distinct().ToList();

            return output;
        }

        /// <summary>
        /// Получить полное имя одного товара
        /// </summary>
        /// <param name="Id">id записи</param>
        /// <returns>полное имя</returns>
        private string GetOneItem(int Id)
        {
            var output = new Forecast_DataModel
            {
                itemId = RequestItemId(Id),
                itemName = RequestItemName(Id)
            };

            return output.FullItemName;
        }

        /// <summary>
        /// Получить список всех записей
        /// </summary>
        /// <param name="AllIdForecast">Список со всеми id</param>
        /// <returns>список с объектами класса</returns>
        public List<Forecast_DataModel> GetAllForecast(List<int> AllIdForecast)
        {
            var output = new List<Forecast_DataModel>();

            foreach (var i in AllIdForecast)
                output.Add(GetOneForecast(i));
            return output;
        } 

        /// <summary>
        /// получить одну запись
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>объект класса</returns>
        private Forecast_DataModel GetOneForecast(int Id)
        {
            var output = new Forecast_DataModel
            {
                id = Id,
                level0 = RequestLevel0(Id),
                level1 = RequestLevel1(Id),
                level2 = RequestLevel2(Id),
                level3 = RequestLevel3(Id),
                level4 = RequestLevel4(Id),
                inventLocationId = RequestInventLocationId(Id),
                itemId = RequestItemId(Id),
                itemName = RequestItemName(Id),
                date = RequestDate(Id),
                qty20 = RequestQty20(Id),
                qty19 = RequestQty19(Id),
                forecast20 = RequestForecast20(Id)
            };

            return output;
        }

        /// <summary>
        /// Список значений "прогноз на текущий год"
        /// </summary>
        /// <param name="Id">id товара</param>
        /// <returns>список</returns>
        public List<double> GetForecast20ForItem(string Id, DateTime DateStart, DateTime DateEnd)
        {
            var output = new List<double>();
            var list = context.Forecast
                .Where(c => c.itemid == Id 
                && c.date >= DateStart
                && c.date <= DateEnd)
                .Select(c => c.forecast20)
                .ToList();
            foreach (var i in list)
                output.Add((double)i);

            return output;
        }

        /// <summary>
        /// Список значений "факт продаж на прошлый год"
        /// </summary>
        /// <param name="Id">id товара</param>
        /// <returns>список</returns>
        public List<double> GetQty20ForItem(string Id, DateTime DateStart, DateTime DateEnd)
        {
            var output = new List<double>();
            var list = context.Forecast
                .Where(c => c.itemid == Id
                && c.date >= DateStart
                && c.date <= DateEnd)
                .Select(c => c.qty20)
                .ToList();
            foreach (var i in list)
                output.Add((double)i);

            return output;
        }

        /// <summary>
        /// Список значений "факт продаж на текущий год"
        /// </summary>
        /// <param name="Id">id товара</param>
        /// <returns>список</returns>
        public List<double> GetQty19ForItem(string Id, DateTime DateStart, DateTime DateEnd)
        {
            var output = new List<double>();
            var list = context.Forecast
                .Where(c => c.itemid == Id
                && c.date >= DateStart
                && c.date <= DateEnd)
                .Select(c => c.qty19)
                .ToList();
            foreach (var i in list)
                output.Add((double)i);

            return output;
        }

        public string[] GetDateForItem(string Id, DateTime DateStart, DateTime DateEnd)
        {
            var query = context.Forecast
                .Where(c => c.itemid == Id
                && c.date >= DateStart
                && c.date <= DateEnd)
                .Select(c => c.date)
                .ToList();
            var output = new List<string>();
            query.Sort();

            foreach (var i in query)
            {
                string[] str = i.ToString().Split(new char[] { ' ' });

                output.Add(str[0]);
            }

            return output.ToArray();
        }

        #region Получение значений для единичной записи

        /// <summary>
        /// получить 0 уровнь классификации  товара
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestLevel0 (int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.level0)
            .FirstOrDefault();
        

        /// <summary>
        /// получить 1 уровнь классификации  товара
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestLevel1(int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.level1)
            .FirstOrDefault();

        /// <summary>
        /// получить 2 уровнь классификации  товара
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestLevel2(int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.level2)
            .FirstOrDefault();

        /// <summary>
        /// получить 3 уровнь классификации  товара
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestLevel3(int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.level3)
            .FirstOrDefault();

        /// <summary>
        /// получить 4 уровнь классификации  товара
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestLevel4(int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.level4)
            .FirstOrDefault();

        /// <summary>
        /// получить код магазина
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestInventLocationId(int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.inventlocationid)
            .FirstOrDefault();

        /// <summary>
        /// получить код артикула
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestItemId(int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.itemid)
            .FirstOrDefault();

        /// <summary>
        /// получить имя артикула
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private string RequestItemName(int Id)
            => context.Forecast
            .Where(c => c.id == Id)
            .Select(c => c.itemname)
            .FirstOrDefault();

        /// <summary>
        /// получить Дату
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private DateTime RequestDate(int Id)
        {
            DateTime output = (DateTime)context.Forecast
                              .Where(c => c.id == Id)
                              .Select(c => c.date)
                              .FirstOrDefault();

            return output;
        }

        /// <summary>
        /// получить факт продаж текущего года
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private double RequestQty20(int Id)
            => Convert.ToDouble(context.Forecast
                .Where(c => c.id == Id)
                .Select(c => c.qty20)
                .FirstOrDefault());

        /// <summary>
        /// получить факт продаж предыдущего года
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private double RequestQty19(int Id)
            => Convert.ToDouble(context.Forecast
                .Where(c => c.id == Id)
                .Select(c => c.qty19)
                .FirstOrDefault());

        /// <summary>
        /// получить прогноз текущего года
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private double RequestForecast20(int Id)
            => Convert.ToDouble(context.Forecast
                .Where(c => c.id == Id)
                .Select(c => c.forecast20)
                .FirstOrDefault());

        #endregion
    }
}

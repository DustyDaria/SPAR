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
        private float RequestQty20(int Id)
            => Convert.ToSingle(context.Forecast
                .Where(c => c.id == Id)
                .Select(c => c.qty20)
                .FirstOrDefault());

        /// <summary>
        /// получить факт продаж предыдущего года
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private float RequestQty19(int Id)
            => Convert.ToSingle(context.Forecast
                .Where(c => c.id == Id)
                .Select(c => c.qty19)
                .FirstOrDefault());

        /// <summary>
        /// получить прогноз текущего года
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>значение из бд</returns>
        private float RequestForecast20(int Id)
            => Convert.ToSingle(context.Forecast
                .Where(c => c.id == Id)
                .Select(c => c.forecast20)
                .FirstOrDefault());

        #endregion
    }
}

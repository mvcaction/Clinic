using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiClinic.Models
{
    public class ProductDataSource
    {
        private static readonly IList<ClinicTable> _cachedItems;
        static ProductDataSource()
        {
            _cachedItems = createProductsDataSource();
        }

        public static IList<ClinicTable> LatestProducts
        {
            get { return _cachedItems; }

        }

        /// <summary>
        /// هدف صرفا تهیه یک منبع داده آزمایشی ساده تشکیل شده در حافظه است
        /// </summary>
        private static IList<ClinicTable> createProductsDataSource()
        {
            ClinicEntities CE = new ClinicEntities();
            var lstOfCustomers = new List<ClinicTable>();
            var lst = CE.ClinicTables;
            foreach (var item in lst)
            {


                lstOfCustomers.Add(item);

            }
            return lstOfCustomers;
        }
    }
}
using Riba.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Riba.Common.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Import orders from the CSV document
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Order> ImportOrders(string path)
        {
            var result = new List<Order>();

            using(var fs = File.OpenRead(path))
            {
                using(var reader = new StreamReader(fs))
                {
                    var list = new List<string>();

                    //header
                    if(!reader.EndOfStream)
                        reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        var order = new Order()
                        {
                            OrderId = Convert.ToInt32(values[0]),
                            OrderDate = Convert.ToDateTime(values[1]),
                            CustomerName = values[2],
                            UnitPrice = Convert.ToDecimal(values[3]),
                            Quantity = Convert.ToInt32(values[4]),
                        };
                        result.Add(order);
                    }
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace eSaleService
{
    public class OrderService
    {
        /// <summary>
        /// 取得DB連線
        /// </summary>
        /// <returns></returns>



        public List<eSaleModel.Order> Inquire(eSaleModel.Order AllData)
        {
            string SqlData = "Select OrderID, CustName, OrderDate, ShippedDate ";
            string Where = "Where ";
            if (AllData.OrderID != null)
            {
                Where += "a.OrderID = " + AllData.OrderID + " and ";
            }
            if (AllData.CustName != null)
            {
                Where += "CustName = 'Customer IBVRG'" + " and ";
            }
            if (!AllData.EmpName.Equals("null"))
            {
                Where += "a.EmployeeID = " + AllData.EmpName + " and ";
            }
            if (!AllData.CpyName.Equals("null"))
            {
                Where += "d.ShipperID = " + AllData.CpyName + " and ";
            }
            if (AllData.OrderDate != null)
            {
                Where += "OrderDate = '" + AllData.OrderDate.Substring(0, 10) + "' and ";

            }
            if (AllData.RequiredDate != null)
            {
                Where += "RequiredDate = '" + AllData.RequiredDate.Substring(0, 10) + "' and ";
            }
            if (AllData.ShippedDate != null)
            {
                Where += "ShippedDate = '" + AllData.ShippedDate.Substring(0, 10) + "' and ";
            }
            if (Where.Equals("Where "))
            {
                Where = "";
            }
            List<eSaleModel.Order> Data = DoData(SqlData, (Where.Substring(0, Where.Length - 5)), AllData);
            return Data;
        }

        public void Delect(eSaleModel.Order AllData)
        {
            string SqlData = "Delect ";
            string Where = "a.OrderID = " + AllData;
            DoData(SqlData, Where, AllData);
        }


        public List<eSaleModel.Order> DoData(string SqlData, string Where, eSaleModel.Order AllData)
        {
            DataTable dt = new DataTable();
            string Sql = @SqlData + "from Sales.Orders a inner join Sales.Customers b " +
                                  "on b.CustomerID = a.CustomerID " +
                                  "inner join HR.Employees c " +
                                  "on c.EmployeeID = a.EmployeeID " +
                                  "inner join Sales.Shippers d " +
                                  "on d.ShipperID = a.ShipperID " +
                                  Where;


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql, conn);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            List<eSaleModel.Order> Data = new List<eSaleModel.Order>();
            Data = MapOrderDataToList(dt);
            return Data;

        }




        private List<eSaleModel.Order> MapOrderDataToList(DataTable orderData)
        {

            List<eSaleModel.Order> result = new List<eSaleModel.Order>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(
                    new eSaleModel.Order
                    {
                        OrderID = row["OrderID"].ToString(),
                        CustName = row["CustName"].ToString(),
                        OrderDate = row["OrderDate"].ToString(),
                        ShippedDate = row["ShippedDate"].ToString()
                    }
                );
            }

            return result;
        }

    }
}
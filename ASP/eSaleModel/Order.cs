using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace eSaleModel
{
    public class Order
    {
        /// <summary>
        /// 客戶代號
        /// </summary>
        [DisplayName("客戶編號")]
        [MaxLength(3)]
        public string CustomerID { get; set; }

        /// <summary>
        /// 客戶名稱
        /// </summary>
        [DisplayName("客戶名稱")]
        public string CustName { get; set; }

        /// <summary>
        /// 員工編號
        /// </summary>    
        [DisplayName("員工編號")]
        public string EmployeeID { get; set; }

        /// <summary>
        /// 員工名稱
        /// </summary>
        [DisplayName("員工名稱")]
        public string EmpName { get; set; }

        /// <summary>
        /// 貨物運費
        /// </summary>
        [DisplayName("貨物運費")]
        public string Freight { get; set; }

        /// <summary>
        /// 訂單日期
        /// </summary>
        [DisplayName("訂單日期")]
        public string OrderDate { get; set; }
        /// <summary>
        /// 訂單編號
        /// </summary>
        [DisplayName("訂單編號")]
        [Required()]
        public string OrderID { get; set; }

        /// <summary>
        /// 需要日期
        /// </summary>
        [DisplayName("需要日期")]
        public string RequiredDate { get; set; }

        /// <summary>
        /// 出貨地址
        /// </summary>
        [DisplayName("出貨地址")]
        public string ShipAddress { get; set; }

        /// <summary>
        /// 出貨城市
        /// </summary>
        [DisplayName("出貨城市")]
        public string ShipCity { get; set; }

        /// <summary>
        /// 出貨國家
        /// </summary>
        [DisplayName("出貨國家")]
        public string ShipCountry { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        [DisplayName("出貨日期")]
        public string ShippedDate { get; set; }

        /// <summary>
        /// 出貨編號
        /// </summary>
        [DisplayName("出貨編號")]
        public string ShipperId { get; set; }

        /// <summary>
        /// 郵政區號
        /// </summary>
        [DisplayName("郵政區號")]
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// 出貨地區
        /// </summary>
        [DisplayName("出貨地區")]
        public string ShipRegion { get; set; }

        /// <summary>
        /// 公司名稱
        /// </summary>
        [DisplayName("公司名稱")]
        public string CpyName { get; set; }

        
        
    }
}

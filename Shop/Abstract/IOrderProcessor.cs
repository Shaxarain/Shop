using Shop;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcs
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, PurchasingDetail shippingDetail);
    }
}

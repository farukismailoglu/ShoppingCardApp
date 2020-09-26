using System;
using System.Collections.Generic;
using System.Text;

namespace Trendyol.ShoppingCart.Service.Util
{
    public class Helper
    {
        public static R DoWorkForService<R>(Func<R> func, string msg)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is ServiceException ? ex.InnerException : ex);
            }
        }

        public static void DoWorkForService(Action action, string msg)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is ServiceException ? ex.InnerException : ex);
            }
        }
    }
}

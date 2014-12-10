using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel
{
    class DateConfig{        

        internal static String GetDate(){
            
            //Devuele la fecha seteada en el app.config
            return Properties.Settings.Default.Fecha.ToString("yyyyMMdd");
        }             
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class DateProvider
    {
        private static DateProvider instance = null;

        public static DateProvider getInstance()
        {
            if (instance == null)
                instance = new DateProvider();
            return instance;
        }

        //TODO:  convert DateProvider to IDateProvider and use dependency injection to push differnt
        // version, for productoin use IDateProvider that doesnt have SetBackDate, in testing 
        // cast IDateProvider to the test provider that would have SetBackDate. 
        private DateTime BackDate;
        public void SetBackDate(DateTime date)
        {
            BackDate = date;
        }

        public DateTime now()
        {
            return BackDate != DateTime.MinValue ? BackDate : DateTime.Now;
        }
    }
}

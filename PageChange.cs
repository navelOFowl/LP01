using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroyMat
{
    class PageChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static int countitems = 5;
        public int[] NPage { get; set; } = new int[countitems];
        public string[] Visible { get; set; } = new string[countitems];
        public string[] Bold { get; set; } = new string[countitems];
        int countpages;
        public int CountPages
        {
            get => countpages;
            set
            {
                countpages = value;
                for (int i = 1; i < countitems; i++)
                {
                    if (CountPages <= i)
                    {
                        Visible[i] = "Hidden";
                    }
                    else
                    {
                        Visible[i] = "Visible";
                    }
                }
            }
        }

        int countpage;
        public int CountPage
        {
            get => countpage;
            set
            {
                countpage = value;
                if (Countlist % value == 0)
                {
                    CountPages = Countlist / value;
                }
                else
                {
                    CountPages = Countlist / value + 1;
                }
            }
        }

        int countlist;
        public int Countlist
        {
            get => countlist;
            set
            {
                countlist = value;
                if (value % CountPage == 0)
                {
                    CountPages = value / CountPage;
                }
                else
                {
                    CountPages = 1 + value / CountPage;
                }
            }
        }
        int currentpage;
        public int CurrentPage
        {
            get => currentpage;
            set
            {
                currentpage = value;
                if (currentpage < 1)
                {
                    currentpage = 1;
                }
                if (currentpage >= CountPages)
                {
                    currentpage = CountPages;
                }                        
                for (int i = 0; i < countitems; i++)
                {
                    if (currentpage < (1 + countitems / 2) || CountPages < countitems) NPage[i] = i + 1;
                    else if (currentpage > CountPages - (countitems / 2 + 1)) NPage[i] = CountPages - (countitems - 1) + i;
                    else NPage[i] = currentpage + i - (countitems / 2);
                }
                for (int i = 0; i < countitems; i++)
                {
                    if (NPage[i] == currentpage) Bold[i] = "ExtraBold";
                    else Bold[i] = "Regular";
                }
                PropertyChanged(this, new PropertyChangedEventArgs("NPage"));
                PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
                PropertyChanged(this, new PropertyChangedEventArgs("Bold"));
            }
        }
        public PageChange()
        {
            for (int i = 0; i < countitems; i++)
            {
                Visible[i] = "Visible";
                NPage[i] = i + 1;
                Bold[i] = "Regular";
            }
            currentpage = 1;
            countpage = 1;  
            countlist = 1;  
        }
    }
}

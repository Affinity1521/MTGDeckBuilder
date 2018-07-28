using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtgApiManager.Lib;
using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Dto;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Utility;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace MTGDeckBuilder
{
    public class MainApp
    {
        private ObservableCollection<Card> _cardsCollection = null;
        private RelayCommand _cardSearchCommand;
        private string _cardSearchString = null;
        private bool _isLoading = false;

        public MainApp()
        {
            this._cardsCollection = new ObservableCollection<Card>();
        }

        public static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("test");
                CardService cardService = new CardService();
                cardService.Where(c => c.Name, "Karn");

                var result = cardService.All();
                MtgApiManager.Lib.Model.Card[] array = result.Value.ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i].Name + "\n" + array[i].Text);
                    Console.WriteLine(array[i].ImageUrl);
                }
                Console.ReadKey();
            });

            t1.Wait();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();
        int wynikGry = 0;
        int wynikRzutow = 0;
        List<Image> kostki = new List<Image>();
        public MainPage()
        {
            InitializeComponent();
            kostki.AddRange(new Image[]
            {
                kostka1, kostka2, kostka3, kostka4, kostka5
            });
        }

        public static int LiczPunkty(List<int> rzutyKostka)
        {
            return rzutyKostka
                    .GroupBy(rzut => rzut)
                    .Where(grupaRzutow => grupaRzutow.Count() >= 2)
                    .SelectMany(grupaRzutow => Enumerable.Repeat(grupaRzutow.Key, grupaRzutow.Count()))
                    .ToList()
                    .Sum();
        }

        private void RzutKoscmi_Clicked(object sender, EventArgs e)
        {
            List<int> rzutyKostka = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                int wynik = random.Next(1, 7);
                rzutyKostka.Add(wynik);
                kostki[i - 1].Source = $"liczba{wynik}.png";
                
            }
            wynikRzutow = LiczPunkty(rzutyKostka);
            wynikGry += wynikRzutow;
            wynikGryEtykieta.Text = "Wynik gry: " + wynikGry;
            wynikLos.Text = "Wynik tego losowania: " + wynikRzutow;
            wynikRzutow = 0;
        }   
        private void Resetuj_Clicked(object sender, EventArgs e)
        {
            kostki.ForEach(kostki => kostki.Source = "question.jpg");
            wynikGry = 0;
            wynikGryEtykieta.Text = "Wynik gry: " + wynikGry;
            wynikLos.Text = "Wynik tego losowania: " + wynikRzutow;
        }

    }
}

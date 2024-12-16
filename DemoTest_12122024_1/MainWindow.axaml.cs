using Avalonia.Controls;
using DemoTest_12122024_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoTest_12122024_1
{
    public partial class MainWindow : Window
    {
        List<Product> ProductLoang = new List<Product>();
        List<Manufacturer> manufacturerList = new List<Manufacturer>();
        public MainWindow()
        {
            InitializeComponent();
            ComBoxCost.SelectionChanged += ComBoxCost_SelectionChanged;
            ComBoxManufacturer.SelectionChanged += ComBoxManufacturer_SelectionChanged;

            // обновление/загрузка данных
            //Создаем метод для загрузки данных в листбокс
            ListBoxUpdate();
            Loang();
        }
        public void ListBoxUpdate() 
        {
            //Заносим данные в листбокс
            manufacturerList = Helper.DataBases.Manufacturers.ToList();
            //Добавляем новые данные в листбокс, тут новый элемнет
            manufacturerList.Add(new Manufacturer() { ManufacturerName = "Фильтрация"});
            // Устанавливаем добавленый элемент первым "Тоесть 0 значением"
            ComBoxManufacturer.ItemsSource = manufacturerList.OrderByDescending(x =>x.ManufacturerName == "Фильтрация").ToList();
            //Установка элемента являющегося 0 в комбобоксе
            ComBoxManufacturer.SelectedIndex = 0;
        }
        public void Loang() 
        {
            //Выгрузка данных
            ProductLoang = Helper.DataBases.Products.ToList();

            // Выбор сортировки "Цена на Б и М"
            if (ComBoxCost.SelectedIndex == 1) 
            {
                ProductLoang = ProductLoang.OrderBy(x => x.ProductCost).ToList();
            }
            else if (ComBoxCost.SelectedIndex == 2)
            {
                ProductLoang = ProductLoang.OrderByDescending(x => x.ProductCost).ToList();
            }
            // if с комбобоксом фильрацией производителей
            if (ComBoxManufacturer.SelectedIndex > 0)
            {
                // Загружаем выбранные данные из приложения. ОБЯЗАТЕЛЬНО УКАЗЫВАЕМ (Manufacturer)!!!!!
                var selectedManufacturer = (Manufacturer)ComBoxManufacturer.SelectedItem;
                //Звгрузка с выбранным элементов в фильтрации
                ProductLoang = ProductLoang.Where(z => z.ManufacturerId == selectedManufacturer.ManufacturerId).ToList();
            }

            // Поисковик
            var textSearch = (SearchText.Text ?? "").Split(' ');            
            ProductLoang = ProductLoang.Where(x => textSearch.All(next => x.ProductTitle.Contains(next) ||
                                                                          x.ProductDescription.Contains(next))).ToList();

            Vsego.Text = Convert.ToString(Helper.DataBases.Products.Select(x => x.ProductId).Count());
            Pokaz.Text = ProductLoang.Count().ToString();// Показ элементов
            // Выгрузка данных
            ListBox_DemoTest.ItemsSource = ProductLoang;
        }

        private void MenuItem_Click_Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var vibor = ListBox_DemoTest.SelectedItem as Product;
            OkkoRedact okkoRedact = new OkkoRedact(vibor);
            okkoRedact.ShowDialog(this);
            okkoRedact.Closed += (a, b) => Loang();
        }// Редактирование
        private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();
        private void ComBoxCost_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loang();
        private void ComBoxManufacturer_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loang();
        private void Button_Click_Delete(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var vibor = ListBox_DemoTest.SelectedItem as Product;
            Helper.DataBases.Products.Remove(vibor);
            Helper.DataBases.SaveChanges();
            Loang();
        }// Удаление
        private void Button_Click_Dobavit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OkkoRedact okkoRedact = new OkkoRedact();
            okkoRedact.ShowDialog(this);
            okkoRedact.Closed += (a, b) => Loang();
        }// Добавление
    }
}
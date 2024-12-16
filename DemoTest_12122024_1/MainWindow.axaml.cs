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

            // ����������/�������� ������
            //������� ����� ��� �������� ������ � ��������
            ListBoxUpdate();
            Loang();
        }
        public void ListBoxUpdate() 
        {
            //������� ������ � ��������
            manufacturerList = Helper.DataBases.Manufacturers.ToList();
            //��������� ����� ������ � ��������, ��� ����� �������
            manufacturerList.Add(new Manufacturer() { ManufacturerName = "����������"});
            // ������������� ���������� ������� ������ "������ 0 ���������"
            ComBoxManufacturer.ItemsSource = manufacturerList.OrderByDescending(x =>x.ManufacturerName == "����������").ToList();
            //��������� �������� ����������� 0 � ����������
            ComBoxManufacturer.SelectedIndex = 0;
        }
        public void Loang() 
        {
            //�������� ������
            ProductLoang = Helper.DataBases.Products.ToList();

            // ����� ���������� "���� �� � � �"
            if (ComBoxCost.SelectedIndex == 1) 
            {
                ProductLoang = ProductLoang.OrderBy(x => x.ProductCost).ToList();
            }
            else if (ComBoxCost.SelectedIndex == 2)
            {
                ProductLoang = ProductLoang.OrderByDescending(x => x.ProductCost).ToList();
            }
            // if � ����������� ���������� ��������������
            if (ComBoxManufacturer.SelectedIndex > 0)
            {
                // ��������� ��������� ������ �� ����������. ����������� ��������� (Manufacturer)!!!!!
                var selectedManufacturer = (Manufacturer)ComBoxManufacturer.SelectedItem;
                //�������� � ��������� ��������� � ����������
                ProductLoang = ProductLoang.Where(z => z.ManufacturerId == selectedManufacturer.ManufacturerId).ToList();
            }

            // ���������
            var textSearch = (SearchText.Text ?? "").Split(' ');            
            ProductLoang = ProductLoang.Where(x => textSearch.All(next => x.ProductTitle.Contains(next) ||
                                                                          x.ProductDescription.Contains(next))).ToList();

            Vsego.Text = Convert.ToString(Helper.DataBases.Products.Select(x => x.ProductId).Count());
            Pokaz.Text = ProductLoang.Count().ToString();// ����� ���������
            // �������� ������
            ListBox_DemoTest.ItemsSource = ProductLoang;
        }

        private void MenuItem_Click_Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var vibor = ListBox_DemoTest.SelectedItem as Product;
            OkkoRedact okkoRedact = new OkkoRedact(vibor);
            okkoRedact.ShowDialog(this);
            okkoRedact.Closed += (a, b) => Loang();
        }// ��������������
        private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();
        private void ComBoxCost_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loang();
        private void ComBoxManufacturer_SelectionChanged(object? sender, SelectionChangedEventArgs e) => Loang();
        private void Button_Click_Delete(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var vibor = ListBox_DemoTest.SelectedItem as Product;
            Helper.DataBases.Products.Remove(vibor);
            Helper.DataBases.SaveChanges();
            Loang();
        }// ��������
        private void Button_Click_Dobavit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OkkoRedact okkoRedact = new OkkoRedact();
            okkoRedact.ShowDialog(this);
            okkoRedact.Closed += (a, b) => Loang();
        }// ����������
    }
}
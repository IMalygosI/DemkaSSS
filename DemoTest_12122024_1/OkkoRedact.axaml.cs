using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoTest_12122024_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoTest_12122024_1;

public partial class OkkoRedact : Window
{
    List<Activity> activitieSSSs = new List<Activity>();
    Product Productss;
    public OkkoRedact()
    {
        InitializeComponent();
        Productss = new Product();
        ActivityBox();
    }
    public OkkoRedact(Product product)
    {
        InitializeComponent();
        Productss = product;
        OkkoRedacT.DataContext = Productss;
        ActivityBox();
    }

    public void ActivityBox() 
    {
        activitieSSSs = Helper.DataBases.Activities.ToList();
        activitieSSSs.Add(new Activity() { ActivityName = "����� ����������" });
        BoxActive.ItemsSource = activitieSSSs.OrderByDescending(x => x.ActivityName == "����� ����������").ToList();
        BoxActive.SelectedIndex = 0;
    } 
    
    private void Button_Click_Closed(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_Saved(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //�������� �� �� ��� ���� � ���� ������� (��� ������� ��� id �� ����� 0, ���� ����� 0 �� ��������� � else)
        if (Productss.ProductId != 0)
        {
            Helper.DataBases.Products.Update(Productss);
        }
        else
        {
            //�������� ����� � ������ ������� ��� ���������
            Product newProduct = new Product();
            //������ ��������� ������
            newProduct.ProductTitle = ProductTitleN.Text;
            newProduct.ProductDescription = ProductDescriptionN.Text;
            newProduct.ProductCost = Convert.ToDecimal(ProductCostN.Text);

            newProduct.ActiveId = BoxActive.SelectedIndex;//����������

            //�������� ������
            Helper.DataBases.Products.Add(newProduct);
        }
        Helper.DataBases.SaveChanges();
        Close();
    }
}
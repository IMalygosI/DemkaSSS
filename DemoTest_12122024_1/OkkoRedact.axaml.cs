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
        activitieSSSs.Add(new Activity() { ActivityName = "Выбор активности" });
        BoxActive.ItemsSource = activitieSSSs.OrderByDescending(x => x.ActivityName == "Выбор активности").ToList();
        BoxActive.SelectedIndex = 0;

        /*
        if (Productss.ProductId != 0)
        {
            activitieSSSs = Helper.DataBases.Activities.ToList();
            BoxActive.ItemsSource = activitieSSSs.OrderByDescending(x => x.ActivityId == Productss.ActiveId).ToList();
            BoxActive.SelectedIndex = 0;
        }
        else 
        {
            activitieSSSs = Helper.DataBases.Activities.ToList();
            activitieSSSs.Add(new Activity() { ActivityName = "Выбор активности" });
            BoxActive.ItemsSource = activitieSSSs.OrderByDescending(x => x.ActivityName == "Выбор активности").ToList();
            BoxActive.SelectedIndex = 0;
        }
        */
    } 
    
    private void Button_Click_Closed(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click_Saved(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //Проверка на то что нету в базе продука (тут смотрим что id не равен 0, если равен 0 то переходим к else)
        if (Productss.ProductId != 0)
        {
            Productss.ActiveId = BoxActive.SelectedIndex;//Активность
            Helper.DataBases.Products.Update(Productss);
        }
        else
        {
            //Вносим созданные данные
            Productss.ProductTitle = ProductTitleN.Text;
            Productss.ProductDescription = ProductDescriptionN.Text;
            Productss.ProductCost = Convert.ToDecimal(ProductCostN.Text);

            Productss.ActiveId = BoxActive.SelectedIndex;//Активность

            //Загрузка данных
            Helper.DataBases.Products.Add(Productss);
        }
        Helper.DataBases.SaveChanges();
        Close();
    }
}
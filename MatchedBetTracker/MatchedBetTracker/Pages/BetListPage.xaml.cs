﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatchedBetTracker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BetListPage : FreshBaseContentPage
    {
        public BetListPage()
        {
            InitializeComponent();
        }
    }
}
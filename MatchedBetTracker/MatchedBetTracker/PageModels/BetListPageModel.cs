using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;

namespace MatchedBetTracker.PageModels
{
    public class BetListPageModel : FreshBasePageModel
    {
        public ICommand AddNewBetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<AddBetPageModel>();
                });
            }
        }
    }
}

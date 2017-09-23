using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace MatchedBetTracker.PageModels
{
    public class HomePageModel : FreshBasePageModel
    {
        public ICommand AddNewBetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<AddBetPageModel>(null, true);
                });
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }
    }
}

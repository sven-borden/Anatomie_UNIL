using Anatomie_UNIL;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AnatomieUNILWindows
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ResultPage : Page
	{
		Partie Partie = null;
		ObservableCollection<ResultQuestion> QuestionList = new ObservableCollection<ResultQuestion>();
		public ResultPage()
		{
			this.InitializeComponent();
			SystemNavigationManager.GetForCurrentView().BackRequested += ResultPage_BackRequested; ;
			SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
		}

		private void ResultPage_BackRequested(object sender, BackRequestedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			Partie = e.Parameter as Partie;
			for(int i = 0; i < Partie.getListQuestions.Count; i++)
			{
				QuestionList.Add(new ResultQuestion(Partie.getListQuestions[i], Partie.getListAnswer[i], Partie.getListHisAnswer[i]));
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}
	}

	public class ResultQuestion
	{
		public string Question { get; set; }
		public string SysAnswer { get; set; }
		public string HisAnswer { get; set; }
		public bool IsCorrect { get; set; }

		public ResultQuestion(string _question, string _sysAnswer, string _hisAnswer)
		{
			Question = _question;
			SysAnswer = _sysAnswer;
			HisAnswer = _hisAnswer;
			if (SysAnswer == HisAnswer)
			{
				IsCorrect = true;
				SysAnswer = string.Empty;
			}
			else
				IsCorrect = false;
		}
	}
}

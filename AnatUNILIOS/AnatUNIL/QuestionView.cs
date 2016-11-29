using Foundation;
using System;
using UIKit;
using Logic;
using System.Collections.Generic;

namespace AnatUNIL
{
	public partial class QuestionView : UIViewController
	{
		public string ViewTitle = "Default";
		private Partie partie;
		public Settings settings;
		private Question question;
		private NSTimer waiter;
		private string s_membre;
		private int i_membre;
		private string[] listQuestion = null;
		private string realAnswer = null;
		private Random random;

		public QuestionView(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.Title = ViewTitle;
			partie = new Partie(ConvertTitleToMembre());
			question = new Question(ConvertMemberToInt());
			question.settings = this.settings;
			random = new Random();

			SetQuestion();
		}

		void Ticker()
		{
			waiter.Invalidate();
			waiter.Dispose();
			waiter = null;
			SetQuestion();
			Reponse1.SetTitleColor(UIColor.White, UIControlState.Normal);
			Reponse2.SetTitleColor(UIColor.White, UIControlState.Normal);
			Reponse3.SetTitleColor(UIColor.White, UIControlState.Normal);
			Reponse4.SetTitleColor(UIColor.White, UIControlState.Normal);
		}

		private string ConvertTitleToMembre()
		{
			switch (ViewTitle)
			{
				case "Membre supérieur": s_membre = "supérieur"; break;
				case "Membre inférieur": s_membre = "inférieur"; break;
				case "Tronc": s_membre = "tronc"; break;
				case "Tout": s_membre = "tout"; break;
				default: s_membre = "supérieur"; break;
			}
			return s_membre;
		}

		private int ConvertMemberToInt()
		{
			switch(ViewTitle)
			{
				case "Membre supérieur": i_membre = 1; break;
				case "Membre inférieur": i_membre = 2; break;
				case "Tronc": i_membre = 3; break;
				case "Tout": i_membre = 4; break;
				default: i_membre = 1; break;
			}
			return i_membre;
		}

		private void SetQuestion()
		{
			listQuestion = question.getQuestion(partie.getListQuestions);
			if (listQuestion == null)
				return;
			realAnswer = listQuestion[1];
			List<string> q = new List<string>();
			for (int i = 0; i < 4; i++)
				q.Add(listQuestion[i + 1]);
			q = MixArray(q);
			if (q == null)
				return;
			TexteQuestion.Text = listQuestion[0];
			Reponse1.SetTitle(q[0], UIControlState.Normal);
			Reponse2.SetTitle(q[1], UIControlState.Normal);
			Reponse3.SetTitle(q[2], UIControlState.Normal);
			Reponse4.SetTitle(q[3], UIControlState.Normal);

		}

		private List<string> MixArray(List<string> input)
		{
			List<string> randomList = new List<string>();
			int randomIndex = 0;

			while (input.Count > 0)
			{
				randomIndex = random.Next(0, input.Count);
				randomList.Add(input[randomIndex]);
				input.RemoveAt(randomIndex);
			}
			return randomList;
		}

		partial void Response1Click(UIButton sender)
		{
			string answer = sender.Title(UIControlState.Normal);
			if (answer == realAnswer)
			{
				sender.SetTitleColor(UIColor.Green, UIControlState.Normal);
				waiter = NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 1), delegate { Ticker(); });		
			}
			else
				sender.SetTitleColor(UIColor.Red, UIControlState.Normal);
		}

		partial void Reponse2Click(UIButton sender)
		{
			string answer = sender.Title(UIControlState.Normal);
			if (answer == realAnswer)
			{
				sender.SetTitleColor(UIColor.Green, UIControlState.Normal);
				waiter = NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 1), delegate { Ticker(); });
			}
			else
				sender.SetTitleColor(UIColor.Red, UIControlState.Normal);		
		}

		partial void Reponse3Click(UIButton sender)
		{
			string answer = sender.Title(UIControlState.Normal);
			if (answer == realAnswer)
			{
				sender.SetTitleColor(UIColor.Green, UIControlState.Normal);
				waiter = NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 1), delegate { Ticker(); });
			}
			else
				sender.SetTitleColor(UIColor.Red, UIControlState.Normal);
		}

		partial void Reponse4Click(UIButton sender)
		{
			string answer = sender.Title(UIControlState.Normal);
			if (answer == realAnswer)
			{
				sender.SetTitleColor(UIColor.Green, UIControlState.Normal);
				waiter = NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 1), delegate { Ticker(); });
			}
			else
				sender.SetTitleColor(UIColor.Red, UIControlState.Normal);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			var questionView = segue.DestinationViewController as QuestionView;

			if (questionView != null)
				questionView.ViewTitle = (sender as UIButton).Title(UIControlState.Normal).ToString();
		}
	}
}
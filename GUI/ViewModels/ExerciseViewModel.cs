using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TimingService;

namespace GUI.ViewModels
{
	public partial class ExerciseViewModel : ObservableObject, IQueryAttributable
	{
		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private int introTime;

		public ObservableCollection<Round> Rounds { get; set; }

		private Routine _routine;

		[ObservableProperty]
		private bool isIntroState = true;

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			_routine = query["Message"] as Routine;
			Name = _routine.Name;
			IntroTime = _routine.IntroTime;

			Rounds = new ObservableCollection<Round>();
			for (int i = 0; i < _routine.Rounds.Count; ++i)
			{
				Rounds.Add(_routine.Rounds[i]);
			}
			OnPropertyChanged(nameof(Name));
			OnPropertyChanged(nameof(IntroTime));
			OnPropertyChanged(nameof(Rounds));
		}
	}
}
